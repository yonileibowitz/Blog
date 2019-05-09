{% include  share.html %}

---

The posts below include examples and practices which combine the rich query and data management capabilities of **Azure Data Explorer (Kusto)**.
They will provide you with real-life best practices and methodologies, which have all been repeatedly proven in large-scale production environments,
and will help you make sure you make the most out of your Kusto cluster.

<p align="center">
  <img src="resources/images/adx-logo.png">
  <br><br>
  <a href="#who-am-i-and-why-do-i-blog">Who am I, and why do I blog?</a>
</p>

---

## **Queries**

- **[Just another Kusto hacker *(JAKH)*](blog-posts/jakh.md){:target="_blank"}**

- **[Analyzing Uber rides history in Azure Data Explorer (Kusto)](blog-posts/analyzing-uber-rides-history.md){:target="_blank"}**

- **[Analyzing Spotify streaming history in Azure Data Explorer (Kusto)](blog-posts/analyzing-spotify-streaming-history.md){:target="_blank"}**

- **[Analyzing 2 Billion New York City Taxi rides in Azure Data Explorer (Kusto)](blog-posts/analyzing-nyc-taxi-rides.md){:target="_blank"}**

## **Data Ingestion & Management**

- **[Ingesting 2 Billion New York City Taxi rides into Azure Data Explorer (Kusto)](blog-posts/ingesting-nyc-taxi-rides.md){:target="_blank"}**

- **[Update policies for in-place ETL in Azure Data Explorer (Kusto)](blog-posts/update-policies.md){:target="_blank"}**

- **[Why filtering on datetime columns can save you time](blog-posts/datetime-columns.md){:target="_blank"}**

- **[Specifying metadata at ingestion time](blog-posts/ingestion-time-metadata.md){:target="_blank"}**

- **[Advanced data management in Azure Data Explorer (Kusto)](blog-posts/advanced-data-management.md){:target="_blank"}**
    - [Committing multiple bulks of data in a single transaction](blog-posts/advanced-data-management.md#committing-multiple-bulks-of-data-in-a-single-transaction){:target="_blank"}
    - [Back-filling data](blog-posts/advanced-data-management.md#back-filling-data){:target="_blank"}

---

## Wait, let's start over - what is Azure Data Explorer (Kusto)?

### Haven't seen it in action yet?

Why not start off with a couple of videos:

#### Microsoft Ignite, Orlando, September 2018

- [Scott Guthrie](https://www.linkedin.com/in/guthriescott){:target="_blank"}'s keynote - [watch on YouTube](https://www.youtube.com/watch?v=xnmBu4oh7xk&t=1h08m12s){:target="_blank"}
- [Rohan Kumar](https://www.linkedin.com/in/rohankumar){:target="_blank"}'s session - [watch on YouTube](https://www.youtube.com/watch?v=ZaiM89Z01r0&t=58m0s){:target="_blank"}
- [Manoj Raheja](https://www.linkedin.com/in/manoj-raheja-a02b2b32){:target="_blank"}'s introduction to Azure Data Explorer (Kusto) - [watch on YouTube](https://www.youtube.com/watch?v=GT4C84yrb68){:target="_blank"}

#### Techorama, The Netherlands, October 2018

- [Scott Guthrie](https://www.linkedin.com/in/guthriescott)'s keynote - [watch on YouTube](https://www.youtube.com/watch?v=YTWewM_UMOk&feature=youtu.be&t=3074){:target="_blank"}

#### //build, Seattle, May 2019

- [Rohan Kumar](https://www.linkedin.com/in/rohankumar){:target="_blank"}'s session - [watch on YouTube](https://youtu.be/Fjfvz1HToek?t=2758){:target="_blank"}
- [Uri Barash](https://www.linkedin.com/in/uri-barash-7820594/){:target="_blank"}'s session - [watch on YouTube](https://youtu.be/chVFAGX8IYQ){:target="_blank"}

---

### Read more about it

There's lots to learn and read about. I'd recommend starting with the following links:

#### General availability announcement (February 2019)

- [Azure Data Explorer - The fast and highly scalable data analytics service (
Jurgen Willis @ Microsoft Azure blog)](https://azure.microsoft.com/en-us/blog/individually-great-collectively-unmatched-announcing-updates-to-3-great-azure-data-services/){:target="_blank"}

#### Public preview announcement (September 2018)

- [Introducing Azure Data Explorer (Uri Barash @ Microsoft Azure blog)](https://azure.microsoft.com/en-us/blog/introducing-azure-data-explorer){:target="_blank"}
- [Azure Data Explorer Technology 101 (Ziv Caspi @ Microsoft Azure blog)](https://azure.microsoft.com/en-us/blog/azure-data-explorer-technology-101){:target="_blank"}
- [Azure Data Explorer: Whitepaper (Evgeney Ryzhyk @ Microsoft Azure resource center)](https://azure.microsoft.com/en-us/resources/azure-data-explorer){:target="_blank"}

#### Official documentation

- [Azure Data Explorer: Quickstarts and tutorials](https://docs.microsoft.com/en-us/azure/data-explorer){:target="_blank"}
- [Azure Data Explorer: Reference material](https://docs.microsoft.com/en-us/azure/kusto){:target="_blank"}

---

### Other things I think you should know

### Highlights from Azure Data Explorer (Kusto) documentation

- [Creating a cluster and databases](https://docs.microsoft.com/en-us/azure/data-explorer/create-cluster-database-portal){:target="_blank"}
- [Query best practices](https://docs.microsoft.com/en-us/azure/kusto/query/best-practices){:target="_blank"}
- [Schema best practices](https://docs.microsoft.com/en-us/azure/kusto/management/best-practices){:target="_blank"}
- [Ingestion best practices](https://docs.microsoft.com/en-us/azure/kusto/api/netfx/kusto-ingest-best-practices){:target="_blank"}

---

#### Who am I, and why do I blog?

[I'm](https://www.linkedin.com/in/yonileibo/){:target="_blank"} a software engineer, fortunate and humbled to have the opportunity of being part of
an amazing team, who is hard at work building an amazing Big Data platform.

I've closely witnessed how transformative, and in some cases addictive (in a
good way 😊), this technology has become in the lives of tens of thousands of employees of all disciplines in our company, for our partners, and among
our customers.

They (and ourselves) are using it on a regular day-to-day basis, either for ad-hoc research and investigations, or as part of high volume &
high frequency automated flows.

I believe others can leverage it in both similar and new manners, to transform their day to day work, enrich their (Big-)data-driven decision making processes, build new and exciting products and services on top of it, and perhaps most of all - enjoy a technology which
makes all the above both fun, as well as simple.

<p align="center">
  <img src="resources/images/kusto-mojo.jpg">
  <br><br>
</p>

---

{% include  share.html %}
