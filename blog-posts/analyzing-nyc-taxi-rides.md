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
* Comparing query performance of multiple data platforms with different topologies, 
* Gaining insights from the data about topics like rush hour traffic, popular work hours for investment bankers,
  how [Uber](analyzing-uber-rides-history.md){:target="_blank"}, Lyft and their competitors are changing the landscape for taxis, etc.

In this post, I will do some of both.

*Stay Tuned ...*

* TOC
{:toc}

**[Go back home](../index.md)**

{% include  share.html %}