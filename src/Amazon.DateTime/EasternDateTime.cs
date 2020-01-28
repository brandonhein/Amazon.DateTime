namespace Amazon.DateTime
{
    using System;

    public class EasternDateTime : DateTimeBase
    {
        /// <summary>
        /// Creates a EasternDateTime of a specific day
        /// </summary>
        public EasternDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00"))
                .ToUniversalTime()
                .ToEastern();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00")))
                .ToUniversalTime()
                .ToEastern();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToEastern();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        /// <summary>
        /// Creates a new EasternDateTime of 'Today at this time (hours and minutes)'
        /// </summary>
        public EasternDateTime(TimeSpan timeOfDay)
        {
            var easternNow = DateTime.UtcNow.ToEastern();

            Year = easternNow.Year;
            Month = easternNow.Month;
            Day = easternNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToEastern();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        /// <summary>
        /// Get the Current 'Now' time in Eastern Timezone
        /// <para>BEWARE!... as it'll return with the incorrect offset in AWS</para>
        /// <para>Best bet would be to use <see cref="NowString"/></para>
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToEastern();
            }
        }

        /// <summary>
        /// Get the Current 'Now' time in Eastern timezone as a string. 
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string NowString
        {
            get
            {
                return string.Concat(Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"), NowOffsetString);
            }
        }

        /// <summary>
        /// Get the <see cref="TimeSpan"/> hour offset to apply to a utc now time
        /// </summary>
        public static TimeSpan NowOffset
        {
            get
            {
                return TimeSpan.Parse(NowOffsetString);
            }
        }

        /// <summary>
        /// Get the string timespan hour offset to apply to a utc now time
        /// </summary>
        public static string NowOffsetString
        {
            get
            {
                return Now.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;
            }
        }

        /// <summary>
        /// UTC Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset
        {
            get
            {
                return "-04:00";
            }
        }

        /// <summary>
        /// UTC Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset
        {
            get
            {
                return "-05:00";
            }
        }

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the eastern timezone equivalent 
        /// </summary>
        public static EasternDateTime Convert(DateTime utcDateTime)
        {
            var easternTime = utcDateTime.ToUniversalTime();
            return new EasternDateTime(easternTime.Year, easternTime.Month, easternTime.Day, easternTime.Hour, easternTime.Minute, easternTime.Minute, easternTime.Second);
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
    }
}
