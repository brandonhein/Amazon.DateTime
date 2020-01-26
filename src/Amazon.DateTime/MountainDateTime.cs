namespace Amazon.DateTime
{
    using System;

    public class MountainDateTime
    {
        /// <summary>
        /// Get the Current 'Now' time in Mountain Timezone
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToMountain();
            }
        }

        /// <summary>
        /// Get the Current 'Now' time in Mountain timezone as a string. 
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
                return Now.IsInDaylightSavingsTime() ? DaylightOffset : StandardOffset;
            }
        }

        /// <summary>
        /// Hour offset for when in daylight time
        /// </summary>
        public static string DaylightOffset
        {
            get
            {
                return "-06:00";
            }
        }

        /// <summary>
        /// Hour offset for when in standard time
        /// </summary>
        public static string StandardOffset
        {
            get
            {
                return "-07:00";
            }
        }

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the mountain timezone equivalent 
        /// </summary>
        public static DateTime Convert(DateTime utcDateTime)
        {
            return utcDateTime.ToUniversalTime().ToMountain();
        }

        /// <summary>
        /// Parse a utc time string to get the mountain timezone <see cref="DateTime"/>
        /// </summary>
        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return result.ToMountain();
        }

        /// <summary>
        /// TryParse a utc time string to get the mountain timezone <see cref="DateTime"/>
        /// </summary>
        public static bool TryParse(string utcTime, out DateTime mountainDateTime)
        {
            try
            {
                mountainDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                mountainDateTime = default(DateTime);
                return false;
            }
        }
    }
}
