namespace Amazon.DateTime
{
    using System;

    public class HawaiiDateTime : DateTimeBase
    {
        public HawaiiDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00"))
                .ToUniversalTime()
                .ToHawaii();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;
            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay;
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00")))
                .ToUniversalTime()
                .ToHawaii();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;
            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay;
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToHawaii();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay;
        }

        /// <summary>
        /// Get the Current 'Now' time in Hawaii
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToHawaii();
            }
        }

        /// <summary>
        /// Get the Current 'Now' time in Hawaii as a string. 
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string NowString
        {
            get
            {
                return string.Concat(Now.ToString(Format.StandardDateTime), NowOffsetString);
            }
        }

        /// <summary>
        /// Get the <see cref="TimeSpan"/> hour offset to apply to a utc time
        /// </summary>
        public static TimeSpan NowOffset
        {
            get
            {
                return TimeSpan.Parse(NowOffsetString);
            }
        }

        /// <summary>
        /// Get the string timespan hour offset to apply to a utc time
        /// </summary>
        public static string NowOffsetString
        {
            get
            {
                return "-10:00";
            }
        }

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset
        {
            get
            {
                return "-10:00";
            }
        }

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset
        {
            get
            {
                return "-10:00";
            }
        }

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the hawaii timezone equivalent 
        /// </summary>
        public static DateTime Convert(DateTime utcDateTime)
        {
            return utcDateTime.ToUniversalTime().ToHawaii();
        }

        /// <summary>
        /// Parse a utc time string to get the hawaii timezone <see cref="DateTime"/>
        /// </summary>
        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return result.ToEastern();
        }

        /// <summary>
        /// TryParse a utc time string to get the hawaii timezone <see cref="DateTime"/>
        /// </summary>
        public static bool TryParse(string utcTime, out DateTime hawaiianDateTime)
        {
            try
            {
                hawaiianDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                hawaiianDateTime = default(DateTime);
                return false;
            }
        }
    }
}
