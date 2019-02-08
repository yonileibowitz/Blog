---
title: Analyzing 2 Billion New York City Taxi rides in Azure Data Explorer (Kusto)
---
**[Go back home](../index.md)**

{% include  share.html %}

# Analyzing 2 Billion New York City Taxi rides in Azure Data Explorer (Kusto)

The [NYC Taxi & Limousine Commission](https://www1.nyc.gov/site/tlc/index.page){:target="_blank"} makes
historical data about taxi trips and for-hire-vehicle trips (such as [Uber](analyzing-uber-rides-history.md){:target="_blank"},
Lyft, Juno, Via, etc.) [available](https://www1.nyc.gov/site/tlc/about/tlc-trip-record-data.page){:target="_blank"}
for anyone to download and analyze. These records capture pick-up and drop-off dates/times, pick-up and drop-off locations,
trip distances, itemized fares, rate types, payment types, and driver-reported passenger counts.

![](../resources/images/nyc-taxi-theme-2.png)

In a [previous post](ingesting-nyc-taxi-rides.md), I detailed how simple and efficient ingesting this data set into **Kusto (Azure Data Explorer)**.

A quick Google search will show you many people took a 1.x Billion taxi rides data set for a ride, both for:
* Comparing query performance of multiple data platforms with different topologies.
* Gaining insights from the data about topics like rush hour traffic, popular work hours for investment bankers,
  how [Uber](analyzing-uber-rides-history.md){:target="_blank"}, Lyft and their competitors are changing the landscape for taxis, etc.
    * Here's [an example](http://toddwschneider.com/posts/analyzing-1-1-billion-nyc-taxi-and-uber-trips-with-a-vengeance/){:target="_blank"}
      by [Todd W. Schneider](https://github.com/toddwschneider){:target="_blank"}.

In this post, I will do some of both.

* TOC
{:toc}

## Query Performance

### The setup

For the purpose of this evaluation, I used:

1. An **Azure Data Explorer (Kusto)** cluster with `D14_v2` nodes, which I've scaled gradually from 2 to 4, 6 and finally - 8 nodes.
    * These VMs have 16 vCPUs and 112GB of RAM.
        * I later on scaled down the cluster to 2 `D12_v2` (4 vCPUs, 28GB of RAM) nodes, and repeated the same test run.
    * I created this cluster using the [Azure Portal](https://docs.microsoft.com/en-us/azure/data-explorer/create-cluster-database-portal){:target="_blank"}
    * In this cluster, I [created a database](https://docs.microsoft.com/en-us/azure/data-explorer/create-cluster-database-portal#create-a-database){:target="_blank"}
      named `TaxiRides`.
    * In this database, I created the `Trips` table, and ingested the data into it, as I've detailed in a [previous post](ingesting-nyc-taxi-rides.md).
    * I have applied no tweaks or tricks neither during ingestion nor during queries - this is a    fully managed service which takes care of everything for you.
    * The `Trips` table includes **1,547,471,776** records.

        ```
        Trips
        | count
        ```
    
        |Count        |
        |-------------|
        |1,547,471,776|


2. Four basic aggregation queries (detailed [below](#the-results)).

3. A simple application, written using
[Kusto's .NET client library](https://docs.microsoft.com/en-us/azure/kusto/api/netfx/about-kusto-data){:target="_blank"},
in which I replayed these queries over and over again, so that I can look at the percentiles of the query execution times.
    - Needless to say, that C# is just one of the languages in which the 
      [client libraries](https://docs.microsoft.com/en-us/azure/kusto/api/){:target="_blank"} are available.

### The cost

If you're interested in the cost per hour for the different cluster sizes, check out the pricing details using the
[Azure pricing calculator](https://azure.microsoft.com/en-us/pricing/calculator/){:target="_blank"}.

### The results

**Note:** If you're comparing these to other runs available online, make sure you're doing apples-to-apples comparison,
taking into account the size of the data set, the resources, and their cost.

I used [.show queries](https://docs.microsoft.com/en-us/azure/kusto/management/queries){:target="_blank"} to capture, per query:
* The number of executions.
* The minimum execution time.
* The 50th and 95th percentiles of the execution time.

I repeated this for each of the 4 cluster sizes, and these are the results:

#### Q 1

```
Trips
| summarize count()
         by cab_type
```

| QueryId | ClusterSize | Count | min_ExecutionTime | p50          | p95          |
|---------|-------------|-------|-------------------|--------------|--------------|
| Q 1     | 2 x D12v2   | 120   | 00:00:05.188      | 00:00:05.313 | 00:00:05.531 |
| Q 1     | 2 x D14v2   | 200   | 00:00:01.797      | 00:00:01.828 | 00:00:01.906 |
| Q 1     | 4 x D14v2   | 240   | 00:00:01.406      | 00:00:01.453 | 00:00:01.563 |
| Q 1     | 6 x D14v2   | 230   | 00:00:01.375      | 00:00:01.438 | 00:00:01.547 |
| Q 1     | 8 x D14v2   | 260   | 00:00:01.172      | 00:00:01.203 | 00:00:01.250 |

#### Q 2

```
Trips 
| summarize avg(total_amount)
         by passenger_count
```

| QueryId | ClusterSize | Count | min_ExecutionTime | p50          | p95          |
|---------|-------------|-------|-------------------|--------------|--------------|
| Q 2     | 2 x D12v2   | 100   | 00:00:04.484      | 00:00:04.596 | 00:00:04.766 |
| Q 2     | 2 x D14v2   | 200   | 00:00:01.531      | 00:00:01.564 | 00:00:01.687 |
| Q 2     | 4 x D14v2   | 233   | 00:00:01.203      | 00:00:01.250 | 00:00:01.344 |
| Q 2     | 6 x D14v2   | 230   | 00:00:01.187      | 00:00:01.250 | 00:00:01.547 |
| Q 2     | 8 x D14v2   | 260   | 00:00:01.031      | 00:00:01.062 | 00:00:01.219 |

#### Q 3

```
Trips 
| summarize count()
         by passenger_count,
            year = startofyear(pickup_datetime)
```

| QueryId | ClusterSize | Count | min_ExecutionTime | p50          | p95          |
|---------|-------------|-------|-------------------|--------------|--------------|
| Q 3     | 2 x D12v2   | 97    | 00:00:10.016      | 00:00:10.239 | 00:00:10.781 |
| Q 3     | 2 x D14v2   | 198   | 00:00:03.359      | 00:00:03.422 | 00:00:05.281 |
| Q 3     | 4 x D14v2   | 230   | 00:00:02.656      | 00:00:02.703 | 00:00:02.859 |
| Q 3     | 6 x D14v2   | 237   | 00:00:02.609      | 00:00:02.687 | 00:00:02.860 |
| Q 3     | 8 x D14v2   | 258   | 00:00:02.203      | 00:00:02.250 | 00:00:02.953 |

#### Q 4

```
Trips 
| summarize trips = count()
         by passenger_count, 
            year = startofyear(pickup_datetime),
            distance = round(trip_distance)
| order by year asc,
           trips desc
```

| QueryId | ClusterSize | Count | min_ExecutionTime | p50          |  p95          |
|---------|-------------|-------|-------------------|--------------|---------------|
| Q 4     | 2 x D12v2   | 60    | 00:00:15.208      | 00:00:15.454 |  00:00:15.721 |
| Q 4     | 2 x D14v2   | 180   | 00:00:05.125      | 00:00:05.219 |  00:00:06.375 |
| Q 4     | 4 x D14v2   | 230   | 00:00:04.079      | 00:00:04.156 |  00:00:04.391 |
| Q 4     | 6 x D14v2   | 235   | 00:00:04.025      | 00:00:04.109 |  00:00:04.391 |
| Q 4     | 8 x D14v2   | 250   | 00:00:03.562      | 00:00:03.625 |  00:00:03.781 |

*I'd say that's pretty fast, huh?*

## Exploring and Analyzing the data

*Still Analyzing. This is quite the fun experience* 😀 *Stay tuned ...*


**[Go back home](../index.md)**

{% include  share.html %}