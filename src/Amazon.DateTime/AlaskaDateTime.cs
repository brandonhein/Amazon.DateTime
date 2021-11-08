namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class AlaskaDateTime : DateTimeBase
    {
        public AlaskaDateTime(long ticks)
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

            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public AlaskaDateTime(int year, int month, int day)
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

        public AlaskaDateTime(int year, int month, int day, int hour, int minute)
            : this(year, month, day, hour, minute, 0)
        { }

        public AlaskaDateTime(int year, int month, int day, int hour, int minute, int second)
            : this(year, month, day, hour, minute, second, 0)
        { }

        public AlaskaDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
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

            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        private AlaskaDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeSpan offset)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

            Offset = offset;
            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Alaska Timezone
        /// </summary>
        public static AlaskaDateTime Now => Convert(DateTime.UtcNow);

        /// <summary>
        /// Get the Current 'Today' date in Alaska Timezone
        /// </summary>
        public static AlaskaDateTime Today
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
        public static Timezone Timezone => Timezone.Alaska;

        /// <summary>
        /// UTC Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-08:00");

        /// <summary>
        /// UTC Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-09:00");

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to the <see cref="AlaskaDateTime"/> equivalent
        /// </summary>
        public static AlaskaDateTime Convert(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
                return new AlaskaDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

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
                else
                    dtOffset = new DateTimeOffset(dateTime).ToOffset(DaylightOffset);

                return new AlaskaDateTime(dtOffset.Year, dtOffset.Month, dtOffset.Day, dtOffset.Hour, dtOffset.Minute, dtOffset.Second, dtOffset.Millisecond, dtOffset.Offset);
            }

            return default(AlaskaDateTime);
        }

        /// <summary>
        /// Convert a <see cref="DateTimeOffset"/> value to the <see cref="AlaskaDateTime"/> equivalent
        /// </summary>
        public static AlaskaDateTime Convert(DateTimeOffset dateTimeOffset)
            => Convert(dateTimeOffset.UtcDateTime);

        /// <summary>
        /// Parse a datetime string to get the <see cref="AlaskaDateTime"/>
        /// </summary>
        public static AlaskaDateTime Parse(string dateTime)
        {
            var dt = DateTime.Parse(dateTime);
            return Convert(dt);
        }

        /// <summary>
        /// Trys to Parse a datetime string to get the <see cref="AlaskaDateTime"/>
        /// </summary>
        public static bool TryParse(string dateTime, out AlaskaDateTime alaskaDateTime)
        {
            try
            {
                alaskaDateTime = Parse(dateTime);
                return true;
            }
            catch (Exception ex)
            {
                alaskaDateTime = default(AlaskaDateTime);
                return false;
            }
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified time interval to the value of this instance.
        /// </summary>
        public AlaskaDateTime Add(TimeSpan value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.Add(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of days to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddDays(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddDays(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of hours to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddHours(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddHours(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of milliseconds to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddMilliseconds(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of minutes to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddMinutes(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMinutes(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of months to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddMonths(int months)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddMonths(months);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of seconds to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddSeconds(double value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddSeconds(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of ticks to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddTicks(long value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddTicks(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        /// <summary>
        /// Returns a new <seealso cref="AlaskaDateTime"/> object that adds a specified number of years to the value of this instance.
        /// </summary>
        public AlaskaDateTime AddYears(int value)
        {
            var dt = DateTimeOffset.Parse(Value);
            dt = dt.AddYears(value);
            return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
    }
}
