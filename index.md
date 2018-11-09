{% include  share.html %}

**(In a hurry? Jump directly to the [blog posts](#blog-posts))**

---

## Wait, what is Kusto (Azure Data Explorer) ?

There's lots to learn and read about. I'd recommend starting with the following links:

- [Introducing Azure Data Explorer (Uri Barash @ Microsoft Azure blog)](https://azure.microsoft.com/en-us/blog/introducing-azure-data-explorer){:target="_blank"}
- [Azure Data Explorer Technology 101 (Ziv Caspi @ Microsoft Azure blog)](https://azure.microsoft.com/en-us/blog/azure-data-explorer-technology-101){:target="_blank"}
- [Azure Data Explorer: Whitepaper (Evgeney Ryzhyk @ Microsoft Azure resource center)](https://azure.microsoft.com/en-us/resources/azure-data-explorer){:target="_blank"}
- [Azure Data Explorer: Quickstarts and tutorials](https://docs.microsoft.com/en-us/azure/data-explorer){:target="_blank"}
- [Azure Data Explorer: Reference material](https://docs.microsoft.com/en-us/azure/kusto){:target="_blank"}

## Haven't seen it in action yet ?

Why not start off with a couple of videos:

#### Microsoft Ignite, Orlando, September 2018

- [Scott Guthrie](https://www.linkedin.com/in/guthriescott)'s announcement - [watch on YouTube](https://www.youtube.com/watch?v=xnmBu4oh7xk&t=1h08m12s){:target="_blank"}
- [Rohan Kumar](https://www.linkedin.com/in/rohankumar)'s announcement - [watch on YouTube](https://www.youtube.com/watch?v=ZaiM89Z01r0&t=58m0s){:target="_blank"}
- [Manoj Raheja](https://www.linkedin.com/in/manoj-raheja-a02b2b32)'s introduction to Kusto - [watch on YouTube](https://www.youtube.com/watch?v=GT4C84yrb68){:target="_blank"}

#### Techorama, The Netherlands, October 2018

- [Scott Guthrie](https://www.linkedin.com/in/guthriescott) demoing Kusto - [watch on YouTube](https://www.youtube.com/watch?v=YTWewM_UMOk&feature=youtu.be&t=3074){:target="_blank"}

---
## Other things I think you should know

The posts below includes examples and practices which combine Kusto's rich query and data management capabilities, providing you with real-life and proven-in-production methodologies, for making the most out of Kusto.

### Blog posts

#### Queries

- [Just another Kusto hacker *(JAKH)*](blog-posts/jakh.md)
- *... More to follow ...*

#### Data Management

- [Update policies for in-place ETL in Azure Data Explorer (Kusto)](blog-posts/update-policies.md)
- [Advanced data management in Azure Data Explorer (Kusto)](blog-posts/advanced-data-management.md)
    - [Committing multiple bulks of data in a single transaction](blog-posts/advanced-data-management.md#committing-multiple-bulks-of-data-in-a-single-transaction)
    - [Back-filling data](blog-posts/advanced-data-management.md#back-filling-data)
- [Why filtering on datetime columns can save you time](blog-posts/datetime-columns.md)
- *... More to follow ...*

### Highlights from Azure Data Explorer (Kusto) documentation

- [Creating a cluster and databases](https://docs.microsoft.com/en-us/azure/data-explorer/create-cluster-database-portal){:target="_blank"}
- [Query best practices](https://docs.microsoft.com/en-us/azure/kusto/query/best-practices){:target="_blank"}
- [Schema best practices](https://docs.microsoft.com/en-us/azure/kusto/management/best-practices){:target="_blank"}
- [Ingestion best practices](https://docs.microsoft.com/en-us/azure/kusto/api/netfx/kusto-ingest-best-practices){:target="_blank"}


{% include  share.html %}