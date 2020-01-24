using System;

namespace Amazon.DateTime.Calculators
{
    public static class DateTimeCalculator
    {
        /// <summary>
        /// Get the nth day of a specific month
        /// </summary>
        public static System.DateTime NthOf(this System.DateTime date, int occurance, DayOfWeek dayOfWeek)
        {
            var firstDay = new System.DateTime(date.Year, date.Month, 1);

            var fOc = firstDay.DayOfWeek == dayOfWeek ? firstDay : firstDay.AddDays(dayOfWeek - firstDay.DayOfWeek);

            if (fOc.Month < date.Month) occurance = occurance + 1;
            return fOc.AddDays(7 * (occurance - 1));
        }

        /// <summary>
        /// Daylight Savings starts on the Second Sunday in March at 2am
        /// https://greenwichmeantime.com/time-zone/rules/usa/
        /// </summary>
        public static System.DateTime DaylightStartDate(this System.DateTime date)
        {
            return new System.DateTime(date.Year, 3, 1).NthOf(2, DayOfWeek.Sunday).AddHours(2);
        }

        /// <summary>
        /// Daylight Savings starts on the Second Sunday in March at 2am
        /// https://greenwichmeantime.com/time-zone/rules/usa/
        /// </summary>
        public static System.DateTime DaylightStartDate()
        {
            return DaylightStartDate(System.DateTime.Now);
        }

        /// <summary>
        /// Daylight Savings ends on the First Sunday in November at 2am
        /// https://greenwichmeantime.com/time-zone/rules/usa/
        /// </summary>
        public static System.DateTime DaylightEndDate(this System.DateTime date)
        {
            return new System.DateTime(date.Year, 11, 1).NthOf(1, DayOfWeek.Sunday).AddHours(2);
        }

        /// <summary>
        /// Daylight Savings ends on the First Sunday in November at 2am
        /// https://greenwichmeantime.com/time-zone/rules/usa/
        /// </summary>
        public static System.DateTime DaylightEndDate()
        {
            return DaylightEndDate(System.DateTime.Now);
        }

        public static bool IsInDaylightSavingsTime(this System.DateTime dateTime)
        {
            return DaylightStartDate() <= dateTime && DaylightEndDate() >= dateTime;
        }

        public static bool IsInDaylightSavingsTime()
        {
            return IsInDaylightSavingsTime(System.DateTime.Now);
        }

        private static System.DateTime DateTimeCoversion(this System.DateTime dateTime, Timezone timezone)
        {
            var dt = dateTime.ToUniversalTime();
            var tz = TimeZoneInfo.Utc;
            var tzInfo = tz.GetTimezoneByCode(timezone);

            var utcOffset = tzInfo.BaseUtcOffset;
            double hourOffset;
            hourOffset = utcOffset.TotalHours;

            dt = dt.AddHours(hourOffset);

            var result = new System.DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return result;
        }

        public static System.DateTime ToEastern(this System.DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Eastern);
        }

        public static System.DateTime ToCentral(this System.DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Central);
        }

        public static System.DateTime ToMountain(this System.DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Mountain);
        }

        public static System.DateTime ToPacific(this System.DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Pacific);
        }

        public static System.DateTime ToAlaska(this System.DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Alaska);
        }

        public static System.DateTime ToHawaii(this System.DateTime dateTime)
        {
            return Calculate(dateTime, Timezone.Hawaii);
        }

        public static System.DateTime Calculate(this System.DateTime dateTime, Timezone timezone)
        {
            var dt = dateTime.DateTimeCoversion(timezone);

            var result = new System.DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return result;
        }
    }
}
