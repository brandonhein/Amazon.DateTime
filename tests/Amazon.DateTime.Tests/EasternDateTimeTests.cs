namespace Amazon.DateTime.Tests
{
    using System;
    using Xunit;

    public class EasternDateTimeTests
    {
        [Fact]
        public void Should_test()
        {
            var now = EasternDateTime.Now;

            var nowString = now.ToString("ddd M/d/yyyy H:mm t");
        }

        [Fact]
        public void Should_recreate_issue()
        {
            var dateTimeString = "2021-05-20T21:55";
            //var dateTime = DateTime.Parse(dateTimeString);

            //var easternDateTime = new EasternDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);

            var easternDateTime = EasternDateTime.Parse(dateTimeString);
        }

        //[Fact]
        //public void Should_take_current_time_now_and_compare_eastern_time_hour_offset_correctly()
        //{
        //    var utcNow = DateTime.UtcNow;
        //    var easternNow = EasternDateTime.Now;
        //
        //    var compare = utcNow.Subtract(easternNow.AddSeconds(-1)); //looking at total hours due to calc offset... add a second to ensure valid test
        //    if (easternNow.IsInDaylightSavingsTime())
        //    {
        //        Assert.Equal(4, compare.Hours);
        //    }
        //    else
        //    {
        //        Assert.Equal(5, compare.Hours);
        //    }
        //}
        //
        //[Fact]
        //public void Should_create_a_new_eastern_time_date()
        //{
        //    var today = DateTime.UtcNow.Date;
        //
        //
        //    var easternStart = new EasternDateTime(today.Year, today.Month, today.Day, 11, 0, 0);
        //    var easternEnd = new EasternDateTime(today.Year, today.Month, today.Day, 19, 55, 0);
        //
        //    var startDate = easternStart.ToUniversalTime();
        //    var endDate = easternEnd.ToUniversalTime();
        //
        //    var result = easternStart > easternEnd;
        //
        //
        //    var central = new CentralDateTime(2020, 1, 26, 8, 51, 8, 900);
        //    var cDate = central.ToUniversalTime();
        //}
    }
}
