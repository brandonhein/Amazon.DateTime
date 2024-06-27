using Xunit;

namespace Amazon.DateTime.Tests
{
    using System;

    public class EasternDateTimeTests
    {
        [Fact]
        public void Should_display_correct_offsets_for_end_of_daylight()
        {
            var novSevth = DateTime.Parse("2021-11-07T06:00:00Z");
            var eastern = EasternDateTime.Convert(novSevth);

            var novSixth10pm = new EasternDateTime(2021, 11, 6, 22, 0, 0);
            var novSixth11pm = new EasternDateTime(2021, 11, 6, 23, 0, 0);
            var novSevth12am = new EasternDateTime(2021, 11, 7);
            var novSevth1am = new EasternDateTime(2021, 11, 7, 1, 0, 0);
            var novSevth2am = new EasternDateTime(2021, 11, 7, 2, 0, 0);
            var novSevth3am = new EasternDateTime(2021, 11, 7, 3, 0, 0);
            var novTenth3am = new EasternDateTime(2021, 11, 10, 3, 0, 0);
        }

        [Fact]
        public void Should_display_correct_offsets_for_start_of_daylight()
        {
            var march14th = DateTime.Parse("2021-03-14T07:59:00Z");
            var eastern = EasternDateTime.Convert(march14th);

            var march13th10pm = new EasternDateTime(2021, 3, 13, 22, 0, 0);
            var march13th11pm = new EasternDateTime(2021, 3, 13, 23, 0, 0);
            var march14th12am = new EasternDateTime(2021, 3, 14);
            var march14th1am = new EasternDateTime(2021, 3, 14, 1, 0, 0);
            var march14th2am = new EasternDateTime(2021, 3, 14, 2, 0, 0);
            var march14th3am = new EasternDateTime(2021, 3, 14, 3, 0, 0);

            var nov15th = new EasternDateTime(2021, 11, 15);
            var feb6th = new EasternDateTime(2021, 2, 6);
            var feb6thUtc = DateTime.Parse("2022-02-06T12:12:12.000Z");
            var feb6th2 = EasternDateTime.Convert(feb6thUtc);

            var july4th2 = EasternDateTime.Parse("2022-07-04T12:12:12.000Z");
            var july4th = new EasternDateTime(2021, 7, 4);
        }

        [Fact]
        public void Should_create_eastern_date_time_by_ticks()
        {
            var ticksForMarch13th10pm = new EasternDateTime(637512696000000000);
            var ticksForMarth14th3am = new EasternDateTime(637512876000000000);
        }

        [Fact]
        public void Should_compare_dateTime_to_its_eastern_dateTime_equilivalt()
        {
            var march14th7amUtc = DateTime.Parse("2021-03-14T07:00:00.000Z");
            var march14th3amEastern = EasternDateTime.Convert(march14th7amUtc);

            var novSeventh8amUtc = DateTime.Parse("2021-11-07T08:00:00.000Z");
            var novSeventh3amEastern = EasternDateTime.Convert(novSeventh8amUtc);

            var novSeventh8amLocal = DateTime.SpecifyKind(DateTime.Parse("2021-11-07T08:00:00"), DateTimeKind.Local);
            var novSeventh8amEastern = EasternDateTime.Convert(novSeventh8amLocal);
        }

        [Fact]
        public void Should_get_me_now_and_today_for_eastern()
        {
            var now = EasternDateTime.Now;
            var today = EasternDateTime.Today;
            var yesterday = today.AddDays(-1);
            var twoDaysAgo = today.AddDays(-2);
        }
    }
}
