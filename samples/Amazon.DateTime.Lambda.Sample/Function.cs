using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Amazon.DateTime.Lambda.Sample
{
    using System;
    using System.Collections.Generic;

    public class Function
    {
        public string FunctionHandler(object input, ILambdaContext context)
        {
            var eastern11am = new EasternDateTime(TimeSpan.Parse("11:00")).Value;
            var eastern755pm = new EasternDateTime(TimeSpan.Parse("19:55")).Value;

            var dictionary = new Dictionary<string, string>()
            {
                { "DateTime.Now", DateTime.Now.ToString(Format.StandardDateTime + "zzz") },
                { "DateTime.UtcNow", DateTime.UtcNow.ToString(Format.StandardDateTime + "zzz") },
                { "EasternDateTime.Now", EasternDateTime.Now.ToString(Format.StandardDateTime + "zzz") },
                { "EasternDateTime.NowString", EasternDateTime.NowString },
                { "Eastern11AM", eastern11am },
                { "Eastern11AMconvertedToUtc", DateTime.Parse(eastern11am).ToUniversalTime().ToString(Format.StandardDateTime + "zzz") },
                { "Eastern755PM", eastern755pm },
                { "Eastern755PMconvertedToUtc", DateTime.Parse(eastern755pm).ToUniversalTime().ToString(Format.StandardDateTime + "zzz") }
            };

            var result = string.Empty;
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
                result = string.Concat(result, item.Key, ": ", item.Value, "\n");
            }

            return result;
        }
    }
}
