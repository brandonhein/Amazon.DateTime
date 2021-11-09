using Xunit;

namespace Amazon.DateTime.Tests
{
    public class SerializationTests
    {
        [Theory]
        [InlineData("{\"SomeDateTime\":\"2021-05-20T12:55:00-04:00\"}")] //<-- happy path
        [InlineData("{\"SomeDateTime\":\"2021-05-20T16:55:00Z\"}")] //<-- also good... as its a UTC ISO format
        [InlineData("{\"SomeDateTime\":\"2021-05-20T09:55:00-07:00\"}")] //<-- another use case where something might send something from another timezone

        [InlineData("{\"SomeDateTime\":1621529700}")] //<-- unix timestamp... we can handle it (working as int64) so we're ready for 2038-01-19
        [InlineData("{\"SomeDateTime\":\"1621529700\"}")]

        [InlineData("{\"SomeDateTime\":\"2021-05-20T12:55:00\"}")] //<-- lazy folks that dont put offsets in... forcing you to guess?!?! our lib assumes it's already set for us in the tz we're using
        [InlineData("{\"SomeDateTime\":\"05/20/2021 12:55:00\"}")] //<-- what animal sends this!?!?! 
        public void Should_deserialize_dateTime_values_correctly(string json)
        {
            var expected = new EasternDateTime(2021, 5, 20, 12, 55, 0);

            var systemTextObj = System.Text.Json.JsonSerializer.Deserialize<Sample>(json);
            Assert.Equal(expected, systemTextObj.SomeDateTime);

            var newtonsoftObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Sample>(json);
            Assert.Equal(expected, newtonsoftObj.SomeDateTime);
        }
    }

    public class Sample
    {
        public EasternDateTime SomeDateTime { get; set; }
    }
}
