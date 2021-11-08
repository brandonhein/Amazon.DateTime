﻿namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class MountainDateTime : DateTimeBase
    {
        public MountainDateTime(long ticks)
        {
            var dt = new DateTimeOffset(ticks, StandardOffset);

            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
            Hour = dt.Hour;
            Minute = dt.Minute;
            Second = dt.Second;
            Millisecond = dt.Millisecond;

            Offset = dt.DateTime.IsInDaylightSavingsTime()
                ? DaylightOffset
                : StandardOffset;

            Date = new MountainDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public MountainDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var standardParse = DateTimeOffset.Parse($"{Year.ToString("0000")}-{Month.ToString("00")}-{Day.ToString("00")}T00:00:00{string.Format("{0:00}:{1:00}", StandardOffset.Hours, StandardOffset.Minutes)}");
            Offset = standardParse.DateTime.IsInDaylightSavingsTime()
                ? DaylightOffset
                : StandardOffset;

            var dtParse = DateTimeOffset.Parse(Value);
            DayOfYear = dtParse.DayOfYear;
            DayOfWeek = dtParse.DayOfWeek;

            Date = this;
        }

        public MountainDateTime(int year, int month, int day, int hour, int minute)
            : this(year, month, day, hour, minute, 0)
        { }

        public MountainDateTime(int year, int month, int day, int hour, int minute, int second)
            : this(year, month, day, hour, minute, second, 0)
        { }

        public MountainDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

            var standardParse = DateTimeOffset.Parse($"{Year.ToString("0000")}-{Month.ToString("00")}-{Day.ToString("00")}T{Hour.ToString("00")}:{Minute.ToString("00")}:{Second.ToString("00")}.{Millisecond.ToString("000")}{string.Format("{0:00}:{1:00}", StandardOffset.Hours, StandardOffset.Minutes)}");
            Offset = standardParse.DateTime.IsInDaylightSavingsTime()
                ? DaylightOffset
                : StandardOffset;

            Date = new MountainDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Eastern Timezone
        /// </summary>
        public static MountainDateTime Now => Convert(DateTime.UtcNow);

        /// <summary>
        /// Get the Current 'Today' date in Eastern Timezone
        /// </summary>
        public static MountainDateTime Today
        {
            get
            {
                var offsetToAdd = new TimeSpan(Math.Abs(StandardOffset.Ticks));

                var dtOffset = new DateTimeOffset(DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc)).ToOffset(offsetToAdd);
                var inDaylight = dtOffset.DateTime.IsInDaylightSavingsTime();
                if (inDaylight)
                {
                    offsetToAdd = new TimeSpan(Math.Abs(DaylightOffset.Ticks));
                    dtOffset = new DateTimeOffset(DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc)).ToOffset(offsetToAdd);
                }

                var result = Convert(dtOffset.DateTime);
                return result.Add(result.Offset);
            }
        }

        /// <summary>
        /// <seealso cref="Amazon.DateTime.Timezone"/> enum assoicated to this class
        /// </summary>
        public static Timezone Timezone => Timezone.Mountain;

        /// <summary>
        /// UTC Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-06:00");

        /// <summary>
        /// UTC Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-07:00");

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to the eastern timezone equivalent 
        /// </summary>
        public static MountainDateTime Convert(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
                return new MountainDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            if (dateTime.Kind == DateTimeKind.Local)
                dateTime = dateTime.ToUniversalTime();

            if (dateTime.Kind == DateTimeKind.Utc)
            {
                var dtOffset = new DateTimeOffset(dateTime).ToOffset(StandardOffset);
                var inDaylight = dtOffset.DateTime.IsInDaylightSavingsTime();
                if (inDaylight)
                    dtOffset = new DateTimeOffset(dateTime).ToOffset(DaylightOffset);

                return new MountainDateTime(dtOffset.Year, dtOffset.Month, dtOffset.Day, dtOffset.Hour, dtOffset.Minute, dtOffset.Second, dtOffset.Millisecond);
            }

            return default(MountainDateTime);
        }

        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> value to the eastern timezone equivalent 
        /// </summary>
        public static MountainDateTime Convert(DateTimeOffset dateTimeOffset)
            => Convert(dateTimeOffset.UtcDateTime);

        /// <summary>
        /// Parse a datetime string to get the <see cref="MountainDateTime"/>
        /// </summary>
        public static MountainDateTime Parse(string dateTime)
        {
            var dt = DateTime.Parse(dateTime);
            return Convert(dt);
        }

        /// <summary>
        /// Trys to Parse a datetime string to get the <see cref="MountainDateTime"/>
        /// </summary>
        public static bool TryParse(string dateTime, out MountainDateTime mountainDateTime)
        {
            try
            {
                mountainDateTime = Parse(dateTime);
                return true;
            }
            catch (Exception ex)
            {
                mountainDateTime = default(MountainDateTime);
                return false;
            }
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified time interval to the value of this instance.
        /// </summary>
        public MountainDateTime Add(TimeSpan value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.Add(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of days to the value of this instance.
        /// </summary>
        public MountainDateTime AddDays(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddDays(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of hours to the value of this instance.
        /// </summary>
        public MountainDateTime AddHours(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddHours(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of milliseconds to the value of this instance.
        /// </summary>
        public MountainDateTime AddMilliseconds(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of minutes to the value of this instance.
        /// </summary>
        public MountainDateTime AddMinutes(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMinutes(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of months to the value of this instance.
        /// </summary>
        public MountainDateTime AddMonths(int months)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMonths(months);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of seconds to the value of this instance.
        /// </summary>
        public MountainDateTime AddSeconds(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddSeconds(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of ticks to the value of this instance.
        /// </summary>
        public MountainDateTime AddTicks(long value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddTicks(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="MountainDateTime"/> object that adds a specified number of years to the value of this instance.
        /// </summary>
        public MountainDateTime AddYears(int value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddYears(value);
            return new MountainDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
    }
}
