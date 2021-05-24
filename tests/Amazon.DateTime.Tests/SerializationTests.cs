using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Amazon.DateTime.Tests
{
    public class SerializationTests
    {
        [Theory]
        [InlineData("{\"SomeDateTime\":\"2021-05-20T12:55:00-04:00\"}")] //<-- happy path
        [InlineData("{\"SomeDateTime\":\"2021-05-20T16:55:00Z\"}")] //<-- also good... as its a UTC ISO format

        [InlineData("{\"SomeDateTime\":\"2021-05-20T12:55:00\"}")] //<-- lazy folks that dont put offsets in... forcing you to guess like wtf?!?!
        [InlineData("{\"SomeDateTime\":\"05/20/2021 12:55:00\"}")] //<-- what animal sends this!?!?!
        public void Should_deserialize_dateTime_values_correctly(string json)
        {
            var expected = new EasternDateTime(2021, 5, 20, 12, 55, 0);

            var obj = JsonSerializer.Deserialize<Sample>(json);

            Assert.Equal(expected, obj.SomeDateTime);
        }
    }

    public class Sample
    {
        public EasternDateTime SomeDateTime { get; set; }
    }
}
