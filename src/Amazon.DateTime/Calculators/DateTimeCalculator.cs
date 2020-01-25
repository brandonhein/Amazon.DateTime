namespace Amazon.DateTime.Calculators
{
    using System;

    public static class DateTimeCalculator
    {
        /// <summary>
        /// Get the nth day of a specific month
        /// </summary>
        public static DateTime NthOf(this DateTime date, int occurance, DayOfWeek dayOfWeek)
        {
            var firstDay = new DateTime(date.Year, date.Month, 1);

            var fOc = firstDay.DayOfWeek == dayOfWeek ? firstDay : firstDay.AddDays(dayOfWeek - firstDay.DayOfWeek);

            if (fOc.Month < date.Month) occurance = occurance + 1;
            return fOc.AddDays(7 * (occurance - 1));
        }

        /// <summary>
        /// Daylight Savings starts on the Second Sunday in March at 2am
        /// https://greenwichmeantime.com/time-zone/rules/usa/
        /// </summary>
        public static DateTime DaylightStartDate(this DateTime date)
        {
            return new DateTime(date.Year, 3, 1).NthOf(2, DayOfWeek.Sunday).AddHours(2);
        }

        /// <summary>
        /// Daylight Savings ends on the First Sunday in November at 2am
        /// https://greenwichmeantime.com/time-zone/rules/usa/
        /// </summary>
        public static DateTime DaylightEndDate(this DateTime date)
        {
            return new DateTime(date.Year, 11, 1).NthOf(1, DayOfWeek.Sunday).AddHours(2);
        }

        /// <summary>
        /// Figures out if the current date time falls inside Daylight savings time
        /// </summary>
        public static bool IsInDaylightSavingsTime(this DateTime dateTime)
        {
            return DaylightStartDate(dateTime) <= dateTime && DaylightEndDate(dateTime) >= dateTime;
        }

        private static DateTime DateTimeCoversion(this DateTime dateTime, Timezone timezone, bool observesDaylight)
        {
            var dt = dateTime.ToUniversalTime();
            var tz = TimeZoneInfo.Utc;
            var tzInfo = tz.GetTimezoneByCode(timezone);

            var utcOffset = tzInfo.BaseUtcOffset;
            double hourOffset;
            hourOffset = utcOffset.TotalHours;

            dt = dt.AddHours(hourOffset);

            if (dateTime.IsInDaylightSavingsTime() && observesDaylight)
            {
                dt = dt.AddHours(-1);
            }

            var result = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return result;
        }

        public static DateTime ToEastern(this DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Eastern, true);
        }

        public static DateTime ToCentral(this DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Central, true);
        }

        public static DateTime ToMountain(this DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Mountain, true);
        }

        public static DateTime ToPacific(this DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Pacific, true);
        }

        public static DateTime ToAlaska(this DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Alaska, true);
        }

        public static DateTime ToHawaii(this DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Hawaii, false);
        }

        private static DateTime Calculate(this DateTime dateTime, Timezone timezone, bool observesDaylight)
        {
            var dt = dateTime.DateTimeCoversion(timezone, observesDaylight);

            var result = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return result;
        }
    }
}
