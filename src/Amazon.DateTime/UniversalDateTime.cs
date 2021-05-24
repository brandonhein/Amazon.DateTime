namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class UniversalDateTime : DateTimeBase
    {
        public UniversalDateTime(long ticks)
        {
            var dateTime = new DateTime(ticks)
                .ToUniversalTime();

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new UniversalDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public UniversalDateTime(int year, int month, int day)
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

        public UniversalDateTime(int year, int month, int day, int hour, int minute, int second)
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

            Date = new UniversalDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public UniversalDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
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

            Date = new UniversalDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public UniversalDateTime(TimeSpan timeOfDay)
        {
            var utcNow = Now;

            Year = utcNow.Year;
            Month = utcNow.Month;
            Day = utcNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("00"), "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new UniversalDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public static UniversalDateTime Now => Convert(DateTime.UtcNow);

        public static UniversalDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow.ToUniversalTime();
                return new UniversalDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        public static Timezone Timezone => Timezone.Default;

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("00:00");

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("00:00");

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the GMT timezone equivalent 
        /// </summary>
        public static UniversalDateTime Convert(DateTime utcDateTime)
        {
            var utcTime = utcDateTime.ToUniversalTime();
            return new UniversalDateTime(utcTime.Year, utcTime.Month, utcTime.Day, utcTime.Hour, utcTime.Minute, utcTime.Second, utcTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the universal (GMT) timezone
        /// </summary>
        public static UniversalDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the universial timezone
        /// </summary>
        public static bool TryParse(string utcTime, out UniversalDateTime universalDateTime)
        {
            try
            {
                universalDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                universalDateTime = default(UniversalDateTime);
                return false;
            }
        }

        public UniversalDateTime Add(TimeSpan value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.Add(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddDays(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddDays(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddHours(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddHours(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddMilliseconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddMinutes(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMinutes(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddMonths(int months)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMonths(months);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddSeconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddSeconds(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddTicks(long value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddTicks(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }

        public UniversalDateTime AddYears(int value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddYears(value);
            return UniversalDateTime.Convert(dt.ToUniversalTime());
        }
    }
}
