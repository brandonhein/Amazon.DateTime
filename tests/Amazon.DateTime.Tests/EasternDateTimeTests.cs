namespace Amazon.DateTime.Tests
{
    using Amazon.DateTime.Calculators;
    using System;
    using Xunit;

    public class EasternDateTimeTests
    {
        [Fact]
        public void Should_take_current_time_now_and_compare_eastern_time_hour_offset_correctly()
        {
            var utcNow = DateTime.UtcNow;
            var easternNow = EasternDateTime.Now;

            var compare = utcNow.Subtract(easternNow.AddSeconds(-1)); //looking at total hours due to calc offset... add a second to ensure valid test
            if (easternNow.IsInDaylightSavingsTime())
            {
                Assert.Equal(4, compare.Hours);
            }
            else
            {
                Assert.Equal(5, compare.Hours);
            }
        }
    }
}
