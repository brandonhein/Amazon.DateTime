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
            => DateTime.SpecifyKind(new DateTime(date.Year, 3, 1).NthOf(2, DayOfWeek.Sunday).AddHours(2), DateTimeKind.Unspecified);

        /// <summary>
        /// Daylight Savings ends on the First Sunday in November at 2am
        /// <para>https://greenwichmeantime.com/time-zone/rules/usa/</para>
        /// </summary>
        internal static DateTime DaylightEndDate(this DateTime date)
            => DateTime.SpecifyKind(new DateTime(date.Year, 11, 1).NthOf(1, DayOfWeek.Sunday).AddHours(2), DateTimeKind.Unspecified);

        /// <summary>
        /// Figures out if the current date time falls inside Daylight savings time
        /// <para>https://greenwichmeantime.com/time-zone/rules/usa/</para>
        /// </summary>
        public static bool IsInDaylightSavingsTime(this DateTime dateTime)
            => DaylightStartDate(dateTime) <= dateTime && DaylightEndDate(dateTime) > dateTime;
    }
}
