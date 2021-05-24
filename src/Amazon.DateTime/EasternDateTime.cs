namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public class EasternDateTime : DateTimeBase
    {
        /// <summary>
        /// Create a EasternDateTime by ticks
        /// </summary>
        public EasternDateTime(long ticks)
        {
            var dateTime = new DateTime(ticks)
                .ToUniversalTime()
                .ToEastern();

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new EasternDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Creates a EasternDateTime of a specific day
        /// </summary>
        public EasternDateTime(int year, int month, int day)
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

        /// <summary>
        /// Creates a EasternDateTime of a specific date and time
        /// </summary>
        public EasternDateTime(int year, int month, int day, int hour, int minute, int second)
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

            Date = new EasternDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Creates a EasternDateTime of a specific date and time
        /// </summary>
        public EasternDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
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

            Date = new EasternDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Creates a new EasternDateTime of 'Today at this time (hours and minutes)'
        /// </summary>
        public EasternDateTime(TimeSpan timeOfDay)
        {
            var easternNow = Now;

            Year = easternNow.Year;
            Month = easternNow.Month;
            Day = easternNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("00"), "Z"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = new EasternDateTime(Year, Month, Day);
            DayOfYear = Date.DayOfYear;
            DayOfWeek = Date.DayOfWeek;
        }

        /// <summary>
        /// Get the Current 'Now' time in Eastern Timezone
        /// </summary>
        public static EasternDateTime Now => Convert(DateTime.UtcNow);

        /// <summary>
        /// Get the Current 'Today' date in Eastern Timezone
        /// </summary>
        public static EasternDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow.ToEastern();
                return new EasternDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        public static Timezone Timezone => Timezone.Eastern;

        /// <summary>
        /// UTC Hour offset for when in daylight time
        /// </summary>
        public static TimeSpan DaylightOffset => TimeSpan.Parse("-04:00");

        /// <summary>
        /// UTC Hour offset for when in standard time
        /// </summary>
        public static TimeSpan StandardOffset => TimeSpan.Parse("-05:00");

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the eastern timezone equivalent 
        /// </summary>
        public static EasternDateTime Convert(DateTime utcDateTime)
        {
            var easternTime = utcDateTime.ToUniversalTime().ToEastern();
            return new EasternDateTime(easternTime.Year, easternTime.Month, easternTime.Day, easternTime.Hour, easternTime.Minute, easternTime.Second, easternTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the eastern timezone
        /// </summary>
        public static EasternDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the eastern timezone
        /// </summary>
        public static bool TryParse(string utcTime, out EasternDateTime easternDateTime)
        {
            try
            {
                easternDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                easternDateTime = default(EasternDateTime);
                return false;
            }
        }

        public EasternDateTime Add(TimeSpan value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.Add(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddDays(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddDays(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddHours(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddHours(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddMilliseconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMilliseconds(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddMinutes(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMinutes(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddMonths(int months)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddMonths(months);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddSeconds(double value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddSeconds(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddTicks(long value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddTicks(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }

        public EasternDateTime AddYears(int value)
        {
            var dt = DateTime.Parse(Value);
            dt = dt.AddYears(value);
            return EasternDateTime.Convert(dt.ToUniversalTime());
        }
    }
}
