namespace Amazon.DateTime
{
    using System;

    public class CentralDateTime : DateTimeBase
    {
        /// <summary>
        /// Create a CentralDateTime by ticks
        /// </summary>
        public CentralDateTime(long ticks)
        {
            var dateTime = new DateTime(ticks)
                .ToUniversalTime()
                .ToCentral();

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

        public CentralDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00"))
                .ToUniversalTime()
                .ToCentral();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public CentralDateTime(int year, int month, int day, int hour, int minute, int second)
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
                .ToCentral();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public CentralDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
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
                .ToCentral();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public CentralDateTime(TimeSpan timeOfDay)
        {
            var centralNow = DateTime.UtcNow.ToCentral();

            Year = centralNow.Year;
            Month = centralNow.Month;
            Day = centralNow.Day;

            Hour = timeOfDay.Hours;
            Minute = timeOfDay.Minutes;
            Second = timeOfDay.Seconds;
            Millisecond = timeOfDay.Milliseconds;

            var dateTimeParse =
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToCentral();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        /// <summary>
        /// Get the Current 'Now' time in Central Timezone
        /// </summary>
        public static CentralDateTime Now => Convert(DateTime.UtcNow);

        public static CentralDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow;
                return new CentralDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset => "-05:00";

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset => "-06:00";

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the central timezone equivalent 
        /// </summary>
        public static CentralDateTime Convert(DateTime utcDateTime)
        {
            var centralTime = utcDateTime.ToUniversalTime().ToCentral();
            return new CentralDateTime(centralTime.Year, centralTime.Month, centralTime.Day, centralTime.Hour, centralTime.Minute, centralTime.Second, centralTime.Millisecond);
        }

        /// <summary>
        /// Parse a utc time string to get the central timezone
        /// </summary>
        public static CentralDateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the central timezone
        /// </summary>
        public static bool TryParse(string utcTime, out CentralDateTime centralDateTime)
        {
            try
            {
                centralDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                centralDateTime = default(CentralDateTime);
                return false;
            }
        }
    }
}
