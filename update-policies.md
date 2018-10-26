# Update policies in Azure Data Explorer (Kusto)

Azure Data Explorer (Kusto) is super fast and efficient in getting your data ingested (, and then queried).

It's usually recommended that your data is formatted to begin with in either of the [supported
data formats](https://docs.microsoft.com/en-us/azure/kusto/management/data-ingestion/#supported-data-formats),
with [CSV](https://tools.ietf.org/html/rfc4180) being the superior choice, in terms of the standard definition of the format, as well the best performance at ingestion time.

In some cases, however, you have no control on the format of the data, but you still want to store it an
efficient manner. In other cases, you may want to enrich the data as it gets ingested into Kusto (e.g. by joining the new records with a static dimension table which is already in your Kusto database). For both of these cases, using an [update policy](https://docs.microsoft.com/en-us/azure/kusto/concepts/updatepolicy) is a very common and powerful practice.

In this post, I will demonstrate how you can leverage an update policy, to take data which is 'structured' in a non-standard format, and restructure it at ingestion time, so that your queries will end up being much more efficient - You will pay a slight (usually negligible) overhead for manipulating the data at ingestion time, however you will gain a
lot in the efficiency of all the queries which will run against your data set.

## The source data

The source data in this example will look as follows:

*(This is by no means a recommendation for how you should format your data/logs. Quite the contrary)*

```
[2018-10-25 04:24:31.1234567Z] [ThreadId:1364] [ProcessId:771] TimeSinceStartup: 0.00:15:12.345 Message: Starting. All systems go.
[2018-10-25 04:26:31.1234567Z] [ThreadId:1364] [ProcessId:771] TimeSinceStartup: 0.00:17:12.345 Message: All components initialized successfully.
...
[2018-10-25 08:18:31.1234567Z] [ThreadId:8945] [ProcessId:598] TimeSinceStartup: 3.14:10:15.123 Message: Shutting down. Thanks for flying.
[2018-10-25 08:19:31.1234567Z] [ThreadId:8945] [ProcessId:598] TimeSinceStartup: 3.14:11:15.123 Message: Shutdown sequence complete. See ya.
```

As you can see above, each line is a single record, which includes a timestamp, and a few other fields, of different types - numerics, strings, timespans, etc.

I could, theoretically, ingest everything into a single column in a Kusto table, then use Kusto's strong query capabilities to parse all records at query time. However, as my data grows and becomes Big Data, query performance will degrade.

## The desired schema

It's quite simple to derive a schema from the data above, and fortunately - it's also very simple to parse it into that schema using Kusto's query language (in this case - using [parse operator](https://docs.microsoft.com/en-us/azure/kusto/query/parseoperator)):

Running this:
```
datatable(OriginalRecord:string)
[
    '[2018-10-25 04:24:31.1234567Z] [ThreadId:1364] [ProcessId:771] TimeSinceStartup: 0.00:15:12.345 Message: Starting. All systems go.',
    '[2018-10-25 04:26:31.1234567Z] [ThreadId:1364] [ProcessId:771] TimeSinceStartup: 0.00:17:12.345 Message: All components initialized successfully.',
    '[2018-10-25 08:18:31.1234567Z] [ThreadId:8945] [ProcessId:598] TimeSinceStartup: 3.14:10:15.123 Message: Shutting down. Thanks for flying.',
    '[2018-10-25 08:19:31.1234567Z] [ThreadId:8945] [ProcessId:598] TimeSinceStartup: 3.14:11:15.123 Message: Shutdown sequence complete. See ya.',
]
| parse OriginalRecord with "[" Timestamp:datetime "] [ThreadId:" ThreadId:int "] [ProcessId:" ProcessId:int "] TimeSinceStartup: " TimeSinceStartup:timespan " Message: " Message:string
| project-away OriginalRecord
```

Yields the following output:

| Timestamp                   | ThreadId | ProcessId | TimeSinceStartup   | Message                                  |
|-----------------------------|----------|-----------|--------------------|------------------------------------------|
| 2018-10-25 04:24:31.1234567 | 1364     | 771       | 00:15:12.3450000   | Starting. All systems go.                |
| 2018-10-25 04:26:31.1234567 | 1364     | 771       | 00:17:12.3450000   | All components initialized successfully. |
| 2018-10-25 08:18:31.1234567 | 8945     | 598       | 3.14:10:15.1230000 | Shutting down. Thanks for flying.        |
| 2018-10-25 08:19:31.1234567 | 8945     | 598       | 3.14:11:15.1230000 | Shutdown sequence complete. See ya.      |

We can actually go ahead and store this as a [function](https://docs.microsoft.com/en-us/azure/kusto/management/functions) in our database, as we're going to use it soon:

```
.create function
 with (docstring = 'Used in the update policy blog post', folder = 'UpdatePolicyFunctions')
 ExtractMyLogs()  
{
    MySourceTable
    | parse OriginalRecord with "[" Timestamp:datetime "] [ThreadId:" ThreadId:int "] [ProcessId:" ProcessId:int "] TimeSinceStartup: " TimeSinceStartup:timespan " Message: " Message:string
    | project-away OriginalRecord
}
```

Great! Now, how can we have this function process the data as it gets ingested?

## Setting up the update policy

I need to have 2 tables in my Kusto database:
- The *source* table - This table will have a single string-typed column, into which I will ingest the source data, as-is.
- The *target* table - This table will have my desired schema. This is the table I define the update policy on.

Each time records get ingestion into my *source* table, the query I will define in my update policy will run on them (and only them - other records in my source table aren't visible to the update policy when it runs), and the results of the query will be appended to my *target* table.

Simple, right? Let's do it!

### Creating the source table

As mentioned before, we're going to put everything in a single string-typed column:

```
.create table MySourceTable (OriginalRecord:string)
```

### Creating the target table

I can use either of the following options:

Explicitly defining the schema:

```
.create table MyTargetTable (Timestamp:datetime, ThreadId:int, ProcessId:int, TimeSinceStartup:timespan, Message:string)
```

Or - using the query to define the schema for me:

Using a [.set command](https://docs.microsoft.com/en-us/azure/kusto/management/data-ingestion/#set-append-set-or-append-set-or-replace), I can create a table with the output schema of my query (this can help me
verify my query actually creates the desired schema):

```
.set MyTargetTable <| 
   print value = ""
   | parse value with "[" Timestamp:datetime "] [ThreadId:" ThreadId:int "] [ProcessId:" ProcessId:int "] TimeSinceStartup: " TimeSinceStartup:timespan " Message: " Message:string
   | limit 0
```

*Note: the* `| limit 0` *suffix is meant to make sure the command actually appends no records to the target table*

### Defining the update policy

> TODO: Continue

### Retaining the raw data (or not)

> TODO: Continue

### Advanced stuff

> TODO: Continue
