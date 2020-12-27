namespace Amazon.DateTime
{
    using System;

    /// <summary>
    /// DateTimeCalculator
    /// </summary>
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
        /// <para>https://greenwichmeantime.com/time-zone/rules/usa/</para>
        /// </summary>
        internal static DateTime DaylightStartDate(this DateTime date)
        {
            return DateTime.SpecifyKind(new DateTime(date.Year, 3, 1).NthOf(2, DayOfWeek.Sunday).AddHours(2), DateTimeKind.Utc);
        }

        /// <summary>
        /// Daylight Savings ends on the First Sunday in November at 2am
        /// <para>https://greenwichmeantime.com/time-zone/rules/usa/</para>
        /// </summary>
        internal static DateTime DaylightEndDate(this DateTime date)
        {
            return DateTime.SpecifyKind(new DateTime(date.Year, 11, 1).NthOf(1, DayOfWeek.Sunday).AddHours(2), DateTimeKind.Utc);
        }

        /// <summary>
        /// Figures out if the current date time falls inside Daylight savings time
        /// <para>https://greenwichmeantime.com/time-zone/rules/usa/</para>
        /// </summary>
        public static bool IsInDaylightSavingsTime(this DateTime dateTime)
        {
            return DaylightStartDate(dateTime) <= dateTime && DaylightEndDate(dateTime) > dateTime;
        }

        private static DateTime DateTimeCoversion(this DateTime dateTime, Timezone timezone, bool observesDaylight)
        {
            var dt = dateTime.ToUniversalTime();
            var tz = TimeZoneInfo.Utc;
            var tzInfo = tz.GetTimezoneByCode(timezone);

            var utcOffset = tzInfo.BaseUtcOffset;
            var hourOffset = utcOffset.TotalHours;

            hourOffset = observesDaylight && dateTime.IsInDaylightSavingsTime()
                ? hourOffset + 1
                : hourOffset;

            dt = dt.AddHours(hourOffset);

            var result = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return result;
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> to an Eastern <see cref="DateTime"/>
        /// <param name="dateTime">DateTime struct to convert</param>
        /// <param name="observesDaylight">If the location observes daylight savings, default value = true</param>
        /// </summary>
        public static DateTime ToEastern(this DateTime dateTime, bool observesDaylight = true)
        {
            return Calculate(dateTime, Timezone.Eastern, observesDaylight);
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> to an Central <see cref="DateTime"/>
        /// <param name="dateTime">DateTime struct to convert</param>
        /// <param name="observesDaylight">If the location observes daylight savings, default value = true</param>
        /// </summary>
        public static DateTime ToCentral(this DateTime dateTime, bool observesDaylight = true)
        {
            return Calculate(dateTime, Timezone.Central, observesDaylight);
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> to an Mountain <see cref="DateTime"/>
        /// <param name="dateTime">DateTime struct to convert</param>
        /// <param name="observesDaylight">If the location observes daylight savings, default value = true</param>
        /// </summary>
        public static DateTime ToMountain(this DateTime dateTime, bool observesDaylight = true)
        {
            return Calculate(dateTime, Timezone.Mountain, observesDaylight);
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> to an Pacific <see cref="DateTime"/>
        /// <param name="dateTime">DateTime struct to convert</param>
        /// <param name="observesDaylight">If the location observes daylight savings, default value = true</param>
        /// </summary>
        public static DateTime ToPacific(this DateTime dateTime, bool observesDaylight = true)
        {
            return Calculate(dateTime, Timezone.Pacific, observesDaylight);
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> to an Alaska <see cref="DateTime"/>
        /// <param name="dateTime">DateTime struct to convert</param>
        /// <param name="observesDaylight">If the location observes daylight savings, default value = true</param>
        /// </summary>
        public static DateTime ToAlaska(this DateTime dateTime, bool observesDaylight = true)
        {
            return Calculate(dateTime, Timezone.Alaska, observesDaylight);
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> to an Hawaii <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">DateTime struct to convert</param>
        /// <param name="observesDaylight">If the location observes daylight savings, default value = false</param>
        public static DateTime ToHawaii(this DateTime dateTime, bool observesDaylight = false)
        {
            return Calculate(dateTime, Timezone.Hawaii, observesDaylight);
        }


        private static DateTime Calculate(this DateTime dateTime, Timezone timezone, bool observesDaylight)
        {
            var dt = dateTime.DateTimeCoversion(timezone, observesDaylight);

            var result = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return result;
        }
    }
}
