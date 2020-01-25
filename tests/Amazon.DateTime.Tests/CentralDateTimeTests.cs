namespace Amazon.DateTime.Tests
{
    using Amazon.DateTime.Calculators;
    using System;
    using Xunit;

    public class CentralDateTimeTests
    {
        [Fact]
        public void Should_take_current_time_now_and_compare_central_time_hour_offset_correctly()
        {
            var utcNow = DateTime.UtcNow;
            var centralNow = CentralDateTime.Now;

            var compare = utcNow.Subtract(centralNow.AddSeconds(-1)); //looking at total hours due to calc offset... add a second to ensure valid test
            if (centralNow.IsInDaylightSavingsTime())
            {
                Assert.Equal(5, compare.Hours);
            }
            else
            {
                Assert.Equal(6, compare.Hours);
            }
        }
    }
}
