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
            var dateTime = new DateTime(ticks)
                .ToUniversalTime()
                .ToAlaska();

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public AlaskaDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month.ToString("00"), "-", Day.ToString("00"), "T00:00:00Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;

            Date = this;
        }

        public AlaskaDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public AlaskaDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("00"), "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public AlaskaDateTime(TimeSpan timeOfDay)
        {
            var alaskaNow = DateTime.UtcNow.ToAlaska();

            Year = alaskaNow.Year;
            Month = alaskaNow.Month;
            Day = alaskaNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("00"), "Z"))
                .ToUniversalTime()
                .ToAlaska();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new AlaskaDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Alaska
        /// </summary>
        public static AlaskaDateTime Now => Convert(DateTime.UtcNow);

        public static AlaskaDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow.ToAlaska();
                return new AlaskaDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        public static Timezone Timezone => Timezone.Alaska;

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-08:00");

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-09:00");

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the alaska equivalent 
        /// </summary>
        public static AlaskaDateTime Convert(DateTime utcDateTime)
        {
            var alaskaTime = utcDateTime.ToUniversalTime().ToAlaska();
            return new AlaskaDateTime(alaskaTime.Year, alaskaTime.Month, alaskaTime.Day, alaskaTime.Hour, alaskaTime.Minute, alaskaTime.Second, alaskaTime.Millisecond);
        }

        /// <summary>
        /// Parse a dateTime string to get the <see cref="AlaskaDateTime"/>
        /// </summary>
        public static AlaskaDateTime Parse(string dateTime)
        {
            var dt = DateTime.Parse(dateTime);
            if (dt.Kind == DateTimeKind.Unspecified)
            {
                return new AlaskaDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            }
            else
            {
                return Convert(dt);
            }
        }

        /// <summary>
        /// TryParse a utc time string to get the alaska <see cref="DateTime"/>
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

        public AlaskaDateTime Add(TimeSpan value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.Add(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddDays(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddDays(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddHours(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddHours(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddMilliseconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddMinutes(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMinutes(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddMonths(int months)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMonths(months);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddSeconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddSeconds(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddTicks(long value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddTicks(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }

        public AlaskaDateTime AddYears(int value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddYears(value);
            return AlaskaDateTime.Convert(dt.ToUniversalTime());
        }
    }
}
