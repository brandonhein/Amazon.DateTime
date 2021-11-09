namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class CentralDateTime : DateTimeBase
    {
        public CentralDateTime(long ticks)
        {
            Kind = Timezone;
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

            Date = new CentralDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public CentralDateTime(int year, int month, int day)
        {
            Kind = Timezone;
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

        public CentralDateTime(int year, int month, int day, int hour, int minute)
            : this(year, month, day, hour, minute, 0)
        { }

        public CentralDateTime(int year, int month, int day, int hour, int minute, int second)
            : this(year, month, day, hour, minute, second, 0)
        { }

        public CentralDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            Kind = Timezone;
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

            var standardParse = DateTimeOffset.Parse($"{Year.ToString("0000")}-{Month.ToString("00")}-{Day.ToString("00")}T{Hour.ToString("00")}:{Minute.ToString("00")}:{Second.ToString("00")}.{Millisecond.ToString("000")}{string.Format("{0:00}:{1:00}", StandardOffset.Hours, StandardOffset.Minutes)}");

            //for the weird instance 2am falls on that DateTime you create
            if (Hour == 2)
            {
                var dayAt2 = DateTimeOffset.Parse($"{Year.ToString("0000")}-{Month.ToString("00")}-{Day.ToString("00")}T{Hour.ToString("00")}:00:00.000{string.Format("{0:00}:{1:00}", StandardOffset.Hours, StandardOffset.Minutes)}");
                var isDaylightStartTime = dayAt2.DateTime.IsDaylightStartDateAndTime();
                if (isDaylightStartTime)
                {
                    Hour = hour + 1;
                    standardParse = DateTimeOffset.Parse($"{Year.ToString("0000")}-{Month.ToString("00")}-{Day.ToString("00")}T{Hour.ToString("00")}:{Minute.ToString("00")}:{Second.ToString("00")}.{Millisecond.ToString("000")}{string.Format("{0:00}:{1:00}", StandardOffset.Hours, StandardOffset.Minutes)}");
                }
            }

            Offset = standardParse.DateTime.IsInDaylightSavingsTime()
                ? DaylightOffset
                : StandardOffset;

            Date = new CentralDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        private CentralDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeSpan offset)
        {
            Kind = Timezone;
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

            Offset = offset;
            Date = new CentralDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Central Timezone
        /// </summary>
        public static CentralDateTime Now => Convert(DateTime.UtcNow);

        /// <summary>
        /// Get the Current 'Today' date in Central Timezone
        /// </summary>
        public static CentralDateTime Today => (CentralDateTime)Now.Date;

        /// <summary>
        /// <seealso cref="Amazon.DateTime.Timezone"/> enum assoicated to this class
        /// </summary>
        public static Timezone Timezone => Timezone.Central;

        /// <summary>
        /// UTC Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-05:00");

        /// <summary>
        /// UTC Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-06:00");

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to the eastern timezone equivalent 
        /// </summary>
        public static CentralDateTime Convert(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
                return new CentralDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            if (dateTime.Kind == DateTimeKind.Local)
                dateTime = dateTime.ToUniversalTime();

            if (dateTime.Kind == DateTimeKind.Utc)
            {
                var dtOffset = new DateTimeOffset(dateTime).ToOffset(StandardOffset);
                var dtOffset2 = new DateTimeOffset(dateTime).ToOffset(DaylightOffset);

                var inDaylight = dtOffset.DateTime.IsInDaylightSavingsTime();
                var inDaylight2 = dtOffset2.DateTime.IsInDaylightSavingsTime();

                if (!inDaylight && inDaylight2 && dtOffset.Month == 3)
                    dtOffset = new DateTimeOffset(dateTime).ToOffset(StandardOffset);
                else if (!inDaylight2 && inDaylight && dtOffset.Month == 11)
                    dtOffset = new DateTimeOffset(dateTime).ToOffset(StandardOffset);
                else if (!inDaylight && !inDaylight2)
                    dtOffset = new DateTimeOffset(dateTime).ToOffset(StandardOffset);
                else
                    dtOffset = new DateTimeOffset(dateTime).ToOffset(DaylightOffset);

                return new CentralDateTime(dtOffset.Year, dtOffset.Month, dtOffset.Day, dtOffset.Hour, dtOffset.Minute, dtOffset.Second, dtOffset.Millisecond, dtOffset.Offset);
            }

            return default(CentralDateTime);
        }

        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> value to the eastern timezone equivalent 
        /// </summary>
        public static CentralDateTime Convert(DateTimeOffset dateTimeOffset)
            => Convert(dateTimeOffset.UtcDateTime);

        /// <summary>
        /// Parse a datetime string to get the <see cref="CentralDateTime"/>
        /// </summary>
        public static CentralDateTime Parse(string dateTime)
        {
            var dt = DateTime.Parse(dateTime);
            return Convert(dt);
        }

        /// <summary>
        /// Trys to Parse a datetime string to get the <see cref="CentralDateTime"/>
        /// </summary>
        public static bool TryParse(string dateTime, out CentralDateTime centralDateTime)
        {
            try
            {
                centralDateTime = Parse(dateTime);
                return true;
            }
            catch (Exception ex)
            {
                centralDateTime = default(CentralDateTime);
                return false;
            }
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified time interval to the value of this instance.
        /// </summary>
        public CentralDateTime Add(TimeSpan value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.Add(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of days to the value of this instance.
        /// </summary>
        public CentralDateTime AddDays(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddDays(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of hours to the value of this instance.
        /// </summary>
        public CentralDateTime AddHours(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddHours(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of milliseconds to the value of this instance.
        /// </summary>
        public CentralDateTime AddMilliseconds(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of minutes to the value of this instance.
        /// </summary>
        public CentralDateTime AddMinutes(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMinutes(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of months to the value of this instance.
        /// </summary>
        public CentralDateTime AddMonths(int months)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMonths(months);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of seconds to the value of this instance.
        /// </summary>
        public CentralDateTime AddSeconds(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddSeconds(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of ticks to the value of this instance.
        /// </summary>
        public CentralDateTime AddTicks(long value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddTicks(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="CentralDateTime"/> object that adds a specified number of years to the value of this instance.
        /// </summary>
        public CentralDateTime AddYears(int value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddYears(value);
            return new CentralDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
    }
}
