namespace Amazon.DateTime
{
    using System;

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
            Ticks = ticks;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            var dateTimeParse = DateTime.Parse(Value);
            Date = dateTimeParse.Date;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public UniversalDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00"))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00")))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public UniversalDateTime(TimeSpan timeOfDay)
        {
            var utcNow = DateTime.UtcNow.ToUniversalTime();

            Year = utcNow.Year;
            Month = utcNow.Month;
            Day = utcNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public static UniversalDateTime Now => Convert(DateTime.UtcNow);

        public static UniversalDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow;
                return new UniversalDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset => "00:00";

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset => "00:00";

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the hawaii timezone equivalent 
        /// </summary>
        public static UniversalDateTime Convert(DateTime utcDateTime)
        {
            var utcTime = utcDateTime.ToUniversalTime();
            return new UniversalDateTime(utcTime.Year, utcTime.Month, utcTime.Day, utcTime.Hour, utcTime.Minute, utcTime.Second, utcTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the hawaii timezone
        /// </summary>
        public static UniversalDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the hawaii timezone
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
    }
}
