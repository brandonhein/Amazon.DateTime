namespace Amazon.DateTime.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;


    public class ComparisonTests
    {
        [Fact]
        public void Should_be_the_same_time_for_all_time_zones()
        {
            var now = DateTime.UtcNow;

            var eastern = new EasternDateTime(now.Year, now.Month, now.Day, 11, 0, 0);
            var central = new CentralDateTime(now.Year, now.Month, now.Day, 10, 0, 0);
            var mountain = new MountainDateTime(now.Year, now.Month, now.Day, 9, 0, 0);
            var pacific = new PacificDateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            var alaska = new AlaskaDateTime(now.Year, now.Month, now.Day, 7, 0, 0);
            var hawaii = new HawaiiDateTime(now.Year, now.Month, now.Day, 6, 0, 0);

            var list = new List<int>();
            list.Add(Compare.Dates(eastern, central));
            list.Add(Compare.Dates(eastern, mountain));
            list.Add(Compare.Dates(eastern, pacific));
            list.Add(Compare.Dates(eastern, alaska));
            list.Add(Compare.Dates(eastern, hawaii));
            list.Add(Compare.Dates(central, mountain));
            list.Add(Compare.Dates(central, pacific));
            list.Add(Compare.Dates(central, alaska));
            list.Add(Compare.Dates(central, hawaii));
            list.Add(Compare.Dates(mountain, pacific));
            list.Add(Compare.Dates(mountain, alaska));
            list.Add(Compare.Dates(mountain, hawaii));
            list.Add(Compare.Dates(pacific, alaska));
            list.Add(Compare.Dates(pacific, hawaii));
            list.Add(Compare.Dates(alaska, hawaii));

            list.ForEach(x =>
            {
                Assert.Equal(0, x);
            });
        }
    }
}
