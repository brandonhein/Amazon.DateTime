namespace Amazon.DateTime.Tests
{
    using System;
    using Xunit;

    public class MountainDateTimeTests
    {
        //[Fact]
        //public void Should_take_current_time_now_and_compare_mountain_time_hour_offset_correctly()
        //{
        //    var utcNow = DateTime.UtcNow;
        //    var mountainNow = MountainDateTime.Now;
        //
        //    var compare = utcNow.Subtract(mountainNow.AddSeconds(-1)); //looking at total hours due to calc offset... add a second to ensure valid test
        //    if (mountainNow.IsInDaylightSavingsTime())
        //    {
        //        Assert.Equal(6, compare.Hours);
        //    }
        //    else
        //    {
        //        Assert.Equal(7, compare.Hours);
        //    }
        //}
    }
}
