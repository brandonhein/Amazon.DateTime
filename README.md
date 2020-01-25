# Amazon.DateTime

The biggest challenge I always have... is remembering timezone offsets.  Working with onprem applications in the eastern timezone, I had no problem with 'if a `DateTime` fell in between two other `DateTime`.  With the big push to get applications into the cloud, the conversion to UTC as messing with my head.  Debugging apps locally suck, especially if folks are using `DateTime.Now` everywhere, since AWS uses UTC.  And linux apps use GMT.  Ughhhh.

Here's a library, trying to help try and eliminate the burden, of remembering UTC-offsets.

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
