using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Amazon.DateTime.Lambda.Sample
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Function
    {
        public string FunctionHandler(object input, ILambdaContext context)
        {
            var sampleObj = new SampleObject()
            {
                DateTime = EasternDateTime.Now,
                Hour = EasternDateTime.Now.Hour,
                Second = EasternDateTime.Now.Second
            };

            var json = JsonConvert.SerializeObject(sampleObj);
            Console.WriteLine(json);

            var sampleJson = "{\"DateTime\":\"2020-01-29T13:49:57.901\",\"Hour\":8,\"Second\":57}";
            var res = JsonConvert.DeserializeObject<SampleObject>(sampleJson);

            Console.WriteLine("sweet serialized");
            Console.WriteLine($"res.Now: {res.DateTime}");
            Console.WriteLine($"res.Hour: {res.Hour}");
            Console.WriteLine($"res.Second: {res.Second}");

            var dictionary = new Dictionary<string, object>()
            {
                { "UniversalDateTime.Now", UniversalDateTime.Now },
                { "EasternDateTime.Now", EasternDateTime.Now },
                { "CentralDateTime.Now", CentralDateTime.Now },
                { "MountainDateTime.Now", MountainDateTime.Now },
                { "PacificDateTime.Now", PacificDateTime.Now },
                { "AlaskaDateTime.Now", AlaskaDateTime.Now },
                { "HawaiiDateTime.Now", HawaiiDateTime.Now }
            };

            var result = string.Empty;
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
                result = string.Concat($"{result} {item.Key} : {item.Value} \n");
            }

            return result;
        }
    }

    public class SampleObject
    {
        public EasternDateTime DateTime { get; set; }
        public int Hour { get; set; }
        public int Second { get; set; }
    }
}
