namespace Amazon.DateTime.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;


    public class ComparisonTests
    {
        [Fact]
        public void Should_be_the_same_time_for_all_time_zones_outside_daylight_savings()
        {
            var dt = new DateTime(2020, 1, 26, 0, 0, 0);

            var eastern = new EasternDateTime(dt.Year, dt.Month, dt.Day, 11, 0, 0);
            var central = new CentralDateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0);
            var mountain = new MountainDateTime(dt.Year, dt.Month, dt.Day, 9, 0, 0);
            var pacific = new PacificDateTime(dt.Year, dt.Month, dt.Day, 8, 0, 0);
            var alaska = new AlaskaDateTime(dt.Year, dt.Month, dt.Day, 7, 0, 0);
            var hawaii = new HawaiiDateTime(dt.Year, dt.Month, dt.Day, 6, 0, 0);

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

        [Fact]
        public void Should_be_the_same_time_for_all_time_zones_inside_a()
        {
            var dt = new DateTime(2020, 6, 26, 0, 0, 0);

            var eastern = new EasternDateTime(dt.Year, dt.Month, dt.Day, 11, 0, 0);
            var central = new CentralDateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0);
            var mountain = new MountainDateTime(dt.Year, dt.Month, dt.Day, 9, 0, 0);
            var pacific = new PacificDateTime(dt.Year, dt.Month, dt.Day, 8, 0, 0);
            var alaska = new AlaskaDateTime(dt.Year, dt.Month, dt.Day, 7, 0, 0);

            //since hawaii doesnt observe... need to tack it on
            var hawaii = new HawaiiDateTime(dt.Year, dt.Month, dt.Day, 5, 0, 0);

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

        [Fact]
        public void Should_calculate_comparison_with_operators()
        {
            var eastern = new EasternDateTime(2020, 6, 26, 11, 0, 0);
            var hawaii = new HawaiiDateTime(2020, 6, 26, 6, 0, 0);

            //6/26/2020 11AM EST (6/26/2020 3PM UTC) 
            //    is earlier than (<)
            //6/26/2020 6AM HST (6/26/2020 4PM UTC)
            Assert.True(eastern < hawaii);
        }
    }
}
