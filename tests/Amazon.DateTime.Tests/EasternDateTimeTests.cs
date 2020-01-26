namespace Amazon.DateTime.Tests
{
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

        [Fact]
        public void Should_create_a_new_eastern_time_date()
        {
            var today = DateTime.UtcNow.Date;


            var easternStart = new EasternDateTime(today.Year, today.Month, today.Day, 11, 0, 0);
            var easternEnd = new EasternDateTime(today.Year, today.Month, today.Day, 19, 55, 0);

            var startDate = easternStart.ToUniversalTime();
            var endDate = easternEnd.ToUniversalTime();



            var central = new CentralDateTime(2020, 1, 26, 8, 51, 8, 900);
            var cDate = central.ToUniversalTime();
        }
    }
}
