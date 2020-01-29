namespace Amazon.DateTime
{
    using System;

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
            Ticks = ticks;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            var dateTimeParse = DateTime.Parse(Value);
            Date = dateTimeParse.Date;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public AlaskaDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00"))
                .ToUniversalTime()
                .ToAlaska();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00")))
                .ToUniversalTime()
                .ToAlaska();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;
            Date = dateTimeParse.Date;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay;
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToAlaska();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToAlaska();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        /// <summary>
        /// Get the Current 'Now' time in Alaska
        /// </summary>
        public static AlaskaDateTime Now => Convert(DateTime.UtcNow);

        public static AlaskaDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow;
                return new AlaskaDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset => "-08:00";

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset => "-09:00";

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the alaska equivalent 
        /// </summary>
        public static AlaskaDateTime Convert(DateTime utcDateTime)
        {
            var alaskaTime = utcDateTime.ToUniversalTime().ToAlaska();
            return new AlaskaDateTime(alaskaTime.Year, alaskaTime.Month, alaskaTime.Day, alaskaTime.Hour, alaskaTime.Minute, alaskaTime.Second, alaskaTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the alaska <see cref="DateTime"/>
        /// </summary>
        public static AlaskaDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the alaska <see cref="DateTime"/>
        /// </summary>
        public static bool TryParse(string utcTime, out AlaskaDateTime alaskaDateTime)
        {
            try
            {
                alaskaDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                alaskaDateTime = default(AlaskaDateTime);
                return false;
            }
        }
    }
}
