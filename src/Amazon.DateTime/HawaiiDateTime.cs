namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class HawaiiDateTime : DateTimeBase
    {
        public HawaiiDateTime(long ticks)
        {
            var dateTime = new DateTime(ticks)
                .ToUniversalTime()
                .ToHawaii();

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new HawaiiDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public HawaiiDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;

            Date = this;
        }

        public HawaiiDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new HawaiiDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public HawaiiDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond, "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new HawaiiDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        public HawaiiDateTime(TimeSpan timeOfDay)
        {
            var hawaiiNow = Now;

            Year = hawaiiNow.Year;
            Month = hawaiiNow.Month;
            Day = hawaiiNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond, "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new HawaiiDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Hawaii
        /// </summary>
        public static HawaiiDateTime Now => Convert(DateTime.UtcNow);

        public static HawaiiDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow.ToHawaii();
                return new HawaiiDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        public static Timezone Timezone => Timezone.Hawaii;

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-10:00");

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-10:00");

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the hawaii timezone equivalent 
        /// </summary>
        public static HawaiiDateTime Convert(DateTime utcDateTime)
        {
            var hawaiiTime = utcDateTime.ToUniversalTime().ToHawaii();
            return new HawaiiDateTime(hawaiiTime.Year, hawaiiTime.Month, hawaiiTime.Day, hawaiiTime.Hour, hawaiiTime.Minute, hawaiiTime.Second, hawaiiTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the hawaii timezone
        /// </summary>
        public static HawaiiDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the hawaii timezone
        /// </summary>
        public static bool TryParse(string utcTime, out HawaiiDateTime hawaiianDateTime)
        {
            try
            {
                hawaiianDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                hawaiianDateTime = default(HawaiiDateTime);
                return false;
            }
        }

        public HawaiiDateTime Add(TimeSpan value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.Add(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddDays(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddDays(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddHours(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddHours(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddMilliseconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddMinutes(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMinutes(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddMonths(int months)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMonths(months);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddSeconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddSeconds(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddTicks(long value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddTicks(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }

        public HawaiiDateTime AddYears(int value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddYears(value);
            return HawaiiDateTime.Convert(dt.ToUniversalTime());
        }
    }
}
