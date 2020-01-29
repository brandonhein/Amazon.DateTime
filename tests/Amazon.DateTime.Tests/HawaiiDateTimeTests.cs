namespace Amazon.DateTime.Tests
{
    using System;
    using Xunit;

    public class HawaiiDateTimeTests
    {
        [Fact]
        public void Should_take_current_time_now_and_compare_central_time_hour_offset_correctly()
        {
            var utcNow = DateTime.UtcNow;
            var hawaiiNow = HawaiiDateTime.Now;

            var compare = utcNow.Subtract(hawaiiNow.AddSeconds(-1)); //looking at total hours due to calc offset... add a second to ensure valid test
            if (hawaiiNow.IsInDaylightSavingsTime())
            {
                Assert.Equal(10, compare.Hours); //hawaii timezone does not use daylight savings... always 10 hour offset!
            }
            else
            {
                Assert.Equal(10, compare.Hours);
            }
        }

        [Fact]
        public void Should_return_negative_10_hours_for_an_offset()
        {
            var offset = HawaiiDateTime.NowOffset;
            Assert.Equal(-10, offset.Hours);
        }

        [Fact]
        public void Should_return_a_now_datetime_string_with_offset()
        {
            var value = HawaiiDateTime.NowString;
        }
    }
}
