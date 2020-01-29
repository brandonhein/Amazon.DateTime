# Amazon.DateTime

Handling timezones and daylight savings can be a nightmare.  Such a 'simple' concept makes everyone gang up on each other.  `DateTime` can be your friend, although, it can bite you in the butt when you deploy your code to an OS doesn't use the same `TimeZoneInfo`.  `DateTime` does magic when it parses, serializes, etc, by auto converting to the local time for you...  

I work in the Eastern Timezone.  But when I deploy to AWS Lambda... it's UTC/GMT time.  So `DateTime.Now` give me two different values (notice how there is NO hour offset):
```csharp
var local = DateTime.Now.ToString(); //2020-01-29T08:56:01.411
var aws = DateTime.Now.ToString(); //2020-01-29T13:56:01.393
```
Makes it very difficult to manage, especially if you have time sensitive requirements, and the requirements are given in for a specific timezone.

At the end of the day, TIME IS TIME!  
![](/.gifs/time_is_time.PNG)

This package allows

### NuGet Information
[AmazonDateTimeConversion](https://www.nuget.org/packages/AmazonDateTimeConversion/)   
![NuGet](https://img.shields.io/nuget/v/AmazonDateTimeConversion.svg?style=flat-square&label=nuget)

Enjoy

### DateTime.Now (for a specific timezone)
Use this library/package to get the 'now' time of the specific timezone
```csharp
var utcNow = DateTime.UtcNow;

//this library converts UTC now to the specified timezone time
DateTime easternNow = EasternDateTime.Now;
DateTime centralNow = CentralDateTime.Now;
DateTime mountainNow = MountainDateTime.Now;
DateTime pacificNow = PacificDateTime.Now;
DateTime alaskaNow = AlaskaDateTime.Now;
DateTime hawaiiNow = HawaiiDateTime.Now;
```

### Convert DateTime to a Timezone
If you need to convert a utc time (use case of a utc time saved in dynamo/handled in your app everywhere), you can convert the date time for your presentation layer. Just use these `DateTime` extensions
```csharp
DateTime eastern = someDateTime.ToEastern();
DateTime central = someDateTime.ToCentral();
DateTime mountain = someDateTime.ToMountain();
DateTime pacific = someDateTime.ToPacific();
DateTime alaskan = someDateTime.ToAlaska();
DateTime hawaiian = someDateTime.ToHawaii();
```

### Daylight savings included! (well mostly...)
In all the time conversions, this package does a check if the date time it's converting falls inside the Daylight Savings timeframe.

Daylight start date: `Second Sunday in March @ 2am`   
Daylight end date: `First Sunday in November @ 2am`  
See https://greenwichmeantime.com/time-zone/rules/usa/ for more information

There's a cool `DateTime` extension you can leverage as well in this library/package
```csharp
var fallsInDaylightSavingsTime = someDateTime.IsInDaylightSavingsTime();
```

#### Things to Note about Daylight Savings
- Daylight savings is administered at the county level. (read up on Arizona Daylight rules) [not considered in this package]
- Hawaii also doesn't practice daylight savings, therefore the entire timezone is impacted [considered in this package]
