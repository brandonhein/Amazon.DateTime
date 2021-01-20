# Amazon.DateTime

### NuGet Information
[AmazonDateTimeConversion](https://www.nuget.org/packages/AmazonDateTimeConversion/)   
![NuGet](https://img.shields.io/nuget/v/AmazonDateTimeConversion.svg?style=flat-square&label=nuget)

![](/.gifs/time_is_time.PNG)

Handling timezones and daylight savings can be a nightmare.  Such a 'simple' concept makes everyone gang up on each other.  `DateTime` can be your friend, although, it can bite you in the butt when you deploy your code to an OS doesn't use the same `TimeZoneInfo`.  `DateTime` does magic when it parses, serializes, etc, by auto converting to the local time for you...  

I work in the Eastern Timezone.  But when I deploy to AWS Lambda... it's UTC/GMT time.  So `DateTime.Now` give me two different values (notice how there is NO hour offset):
```csharp
var local = DateTime.Now.ToString(); //2020-01-29T08:56:01.411
var aws = DateTime.Now.ToString(); //2020-01-29T13:56:01.393
```
Makes it very difficult to manage, especially if you have time sensitive requirements, and the requirements are given in for a specific timezone.

### So what does this package/library do?
All this magic library is it takes a time and owns understanding daylight savings time, and hour offset from UTC.  It also allows for easy operator logic.
#### Get 'Now' but in the eastern sense
```csharp
var easternNow = EasternDateTime.Now;
```
#### Create a timezoneDateTime on specific like 
```csharp
var easternTodayAt755pm = new EasternDateTime(TimeSpan.Parse("19:55")); //timespan for today @ this hour
var christmasAtNoon = new EasternDateTime(2020, 12, 25, 12, 0, 0); //specific day at this time in ET
var easternDateTime = new EasternDateTime(632039429000000); //ticks
```
#### Get the timezoneDateTime as a string that any `DateTime` likes
```csharp
var easternNowAsString = EasternDateTime.Now.ToString(); //2020-01-29T08:56:01.411-05:00
```
#### Easily compare DateTimes with the timezone datetime
```csharp
var eastern11am = new EasternDateTime(TimeSpan.Parse("11:00"));
var eastern545pm = new EasternDateTime(TimeSpan.Parse("17:45"));

var utcNow = DateTime.UtcNow;
var utcfor1145eastern = DateTime.Parse($"{utcDate.Year}-{utcDate.Month}-{utcDate.Day}T16:45:00.000+00:00");

var isBetween = (eastern11am < utcfor1145eastern) && (eastern545pm >= utcfor1145eastern); //true
```
#### Go back to unviersal time if you'd like
```csharp
var utcTime = EasternDateTime.Now.ToUniversalTime(); 
```
#### All USA Timezones are availaible
```csharp
var central = CentralDateTime.Now;
var mountain = MountainDateTime.Now;
var pacific = PacificDateTime.Now;
var alaska = AlaskaDateTime.Now;
var hawaii = HawaiiDateTime.Now;
var universal = UniversalDateTime.Now;
```

![](/.gifs/when_will_then_be_now.gif)  

#### Swagger Definition makes a weird format... what gives!?!?!
Yep. I know. Thats the disadvantage to the object type design pattern.  I set up this library to use both Newtonsoft and System.Text.Json converters (at the attribute level) to serialize and deserialize the `DateTime` string we all know and use.  But when it comes to Swagger model definitions... it still treats these object types like objects.  If you follow my [Hein.Swagger](https://github.com/brandonhein/Hein.Swagger) repository, you can only imagine I like my API documentation to match the output from the API.

To do this you need to create/register the object type in the swagger defintion.  You can do so by doing something like this:
```csharp
services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API"
    });

    //registering the DateTime type you will be using as a string/date-time
    x.MapType<EasternDateTime>(() => 
      new OpenApiSchema() { Type = "string", Format = "date-time" });
});
```

Enjoy
