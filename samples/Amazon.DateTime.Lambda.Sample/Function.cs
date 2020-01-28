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
            var eastern11am = new EasternDateTime(TimeSpan.Parse("11:00"));
            var eastern755pm = new EasternDateTime(TimeSpan.Parse("19:55"));

            var utcDate = DateTime.UtcNow.Date;
            var utcFor1045eastern = DateTime.Parse($"{utcDate.Year}-{utcDate.Month}-{utcDate.Day}T15:45:41.016+00:00");
            var utcfor1145eastern = DateTime.Parse($"{utcDate.Year}-{utcDate.Month}-{utcDate.Day}T16:45:41.016+00:00");

            var isInBetween = (eastern11am < utcFor1045eastern) && (eastern755pm >= utcFor1045eastern);
            var isInBetween2 = (eastern11am < utcfor1145eastern) && (eastern755pm >= utcfor1145eastern);

            var dictionary = new Dictionary<string, string>()
            {
                { "DateTime.Now", DateTime.Now.ToString(Format.StandardDateTime + "zzz") },
                { "DateTime.UtcNow", DateTime.UtcNow.ToString(Format.StandardDateTime + "zzz") },
                { "EasternDateTime.Now", EasternDateTime.Now.ToString(Format.StandardDateTime + "zzz") },
                { "EasternDateTime.NowString", EasternDateTime.NowString },
                { "Eastern11AM", eastern11am.Value },
                { "Eastern11AMconvertedToUtc", DateTime.Parse(eastern11am.Value).ToUniversalTime().ToString(Format.StandardDateTime + "zzz") },
                { "Eastern755PM", eastern755pm.Value },
                { "Eastern755PMconvertedToUtc", DateTime.Parse(eastern755pm.Value).ToUniversalTime().ToString(Format.StandardDateTime + "zzz") },
                { "DoesEastern@11==", (eastern11am == DateTime.Parse(eastern11am.Value)).ToString() },
                { "DoesEastern@755==", (eastern755pm == DateTime.Parse(eastern755pm.Value)).ToString() },
                { "345utc(1045eastern)_fallsbetween_11and755_eastern", isInBetween.ToString() },
                { "445utc(1145eastern)_fallsbetween_11and755_eastern", isInBetween2.ToString() }
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
