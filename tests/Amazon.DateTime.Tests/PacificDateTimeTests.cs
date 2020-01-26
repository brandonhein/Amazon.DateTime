namespace Amazon.DateTime.Tests
{
    using System;
    using Xunit;

    public class PacificDateTimeTests
    {
        [Fact]
        public void Should_take_current_time_now_and_compare_pacific_time_hour_offset_correctly()
        {
            var utcNow = DateTime.UtcNow;
            var pacificNow = PacificDateTime.Now;

            var compare = utcNow.Subtract(pacificNow.AddSeconds(-1)); //looking at total hours due to calc offset... add a second to ensure valid test
            if (pacificNow.IsInDaylightSavingsTime())
            {
                Assert.Equal(7, compare.Hours);
            }
            else
            {
                Assert.Equal(8, compare.Hours);
            }
        }
    }
}
