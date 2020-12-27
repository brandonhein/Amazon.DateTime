namespace Amazon.DateTime
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
            var dateTime = new DateTime(ticks)
                .ToUniversalTime()
                .ToMountain();

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new MountainDateTime(Year, Month, Day);
            var dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        public MountainDateTime(int year, int month, int day)
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

        public MountainDateTime(int year, int month, int day, int hour, int minute, int second)
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

            Date = new MountainDateTime(Year, Month, Day);
            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        public MountainDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
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

            Date = new MountainDateTime(Year, Month, Day);
            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        public MountainDateTime(TimeSpan timeOfDay)
        {
            var mountainNow = DateTime.UtcNow.ToMountain();

            Year = mountainNow.Year;
            Month = mountainNow.Month;
            Day = mountainNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond, "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new MountainDateTime(Year, Month, Day);
            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Mountain Timezone
        /// </summary>
        public static MountainDateTime Now => Convert(DateTime.UtcNow);

        public static MountainDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow.ToMountain();
                return new MountainDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        public static Timezone Timezone => Timezone.Mountain;

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-06:00");

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-07:00");

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the mountain timezone equivalent 
        /// </summary>
        public static MountainDateTime Convert(DateTime utcDateTime)
        {
            var mountainTime = utcDateTime.ToUniversalTime().ToMountain();
            return new MountainDateTime(mountainTime.Year, mountainTime.Month, mountainTime.Day, mountainTime.Hour, mountainTime.Minute, mountainTime.Second, mountainTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the mountain timezone
        /// </summary>
        public static MountainDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the mountain timezone
        /// </summary>
        public static bool TryParse(string utcTime, out MountainDateTime mountainDateTime)
        {
            try
            {
                mountainDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                mountainDateTime = default(MountainDateTime);
                return false;
            }
        }

        public MountainDateTime Add(TimeSpan value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.Add(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddDays(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddDays(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddHours(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddHours(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddMilliseconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddMinutes(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMinutes(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddMonths(int months)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMonths(months);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddSeconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddSeconds(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddTicks(long value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddTicks(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }

        public MountainDateTime AddYears(int value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddYears(value);
            return MountainDateTime.Convert(dt.ToUniversalTime());
        }
    }
}
