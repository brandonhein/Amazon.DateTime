namespace Amazon.DateTime
{
    using System;

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
            Ticks = ticks;

            Offset = dateTime.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            var dateTimeParse = DateTime.Parse(Value);
            Date = dateTimeParse.Date;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        public MountainDateTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            var dateTimeParse = DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T00:00:00"))
                .ToUniversalTime()
                .ToMountain();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00")))
                .ToUniversalTime()
                .ToMountain();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToMountain();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
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
                DateTime.Parse(string.Concat(Year, "-", Month, "-", Day, "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond))
                .ToUniversalTime()
                .ToMountain();

            Offset = dateTimeParse.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;

            dateTimeParse = DateTime.Parse(Value);

            Date = dateTimeParse.Date;
            Ticks = dateTimeParse.Ticks;
            DayOfYear = dateTimeParse.DayOfYear;
            DayOfWeek = dateTimeParse.DayOfWeek;
            TimeOfDay = dateTimeParse.TimeOfDay + TimeSpan.Parse(Offset);
        }

        /// <summary>
        /// Get the Current 'Now' time in Mountain Timezone
        /// </summary>
        public static MountainDateTime Now => Convert(DateTime.UtcNow);

        public static MountainDateTime Today
        {
            get
            {
                var utcNow = DateTime.UtcNow;
                return new MountainDateTime(utcNow.Year, utcNow.Month, utcNow.Day);
            }
        }

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset => "-06:00";

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset => "-07:00";

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
    }
}
