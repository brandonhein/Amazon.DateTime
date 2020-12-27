namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class PacificDateTime : DateTimeBase
    {
        public PacificDateTime(long ticks)
        {
            var dateTime = new DateTime(ticks)
                .ToUniversalTime()
                .ToPacific();

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;
            
            Date = new PacificDateTime(Year, Month, Day);
            var dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        public PacificDateTime(int year, int month, int day)
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

        public PacificDateTime(int year, int month, int day, int hour, int minute, int second)
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

            Date = new PacificDateTime(Year, Month, Day);
            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        public PacificDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
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

            Date = new PacificDateTime(Year, Month, Day);
            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        public PacificDateTime(TimeSpan timeOfDay)
        {
            var pacificNow = DateTime.UtcNow.ToPacific();

            Year = pacificNow.Year;
            Month = pacificNow.Month;
            Day = pacificNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond, "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new PacificDateTime(Year, Month, Day);
            dateTimeParse = DateTime.Parse(Value);
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Pacific Timezone
        /// </summary>
        public static PacificDateTime Now => Convert(DateTime.UtcNow);

        public static PacificDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow.ToPacific();
                return new PacificDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        public static Timezone Timezone => Timezone.Pacific;

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-07:00");

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-08:00");

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the pacific timezone equivalent 
        /// </summary>
        public static PacificDateTime Convert(DateTime utcDateTime)
        {
            var pacificTime = utcDateTime.ToUniversalTime().ToPacific();
            return new PacificDateTime(pacificTime.Year, pacificTime.Month, pacificTime.Day, pacificTime.Hour, pacificTime.Minute, pacificTime.Second, pacificTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the pacific timezone
        /// </summary>
        public static PacificDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the pacific timezone
        /// </summary>
        public static bool TryParse(string utcTime, out PacificDateTime pacificDateTime)
        {
            try
            {
                pacificDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                pacificDateTime = default(PacificDateTime);
                return false;
            }
        }

        public PacificDateTime Add(TimeSpan value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.Add(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddDays(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddDays(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddHours(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddHours(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddMilliseconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddMinutes(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMinutes(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddMonths(int months)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMonths(months);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddSeconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddSeconds(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddTicks(long value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddTicks(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }

        public PacificDateTime AddYears(int value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddYears(value);
            return PacificDateTime.Convert(dt.ToUniversalTime());
        }
    }
}
