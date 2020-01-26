namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class CentralDateTime
    {
        /// <summary>
        /// Get the Current 'Now' time in Central Timezone
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToCentral();
            }
        }

        /// <summary>
        /// Get the Current 'Now' time in Central Timezone as a string. 
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string NowString
        {
            get
            {
                return string.Concat(Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"), OffsetString);
            }
        }

        /// <summary>
        /// Get the <see cref="TimeSpan"/> hour offset to apply to a utc time
        /// </summary>
        public static TimeSpan Offset
        {
            get
            {
                return TimeSpan.Parse(OffsetString);
            }
        }

        /// <summary>
        /// Get the string timespan hour offset to apply to a utc time
        /// </summary>
        public static string OffsetString
        {
            get
            {
                return Now.IsInDaylightSavingsTime() ? "-05:00" : "-06:00";
            }
        }

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the central timezone equivalent 
        /// </summary>
        public static DateTime Convert(DateTime utcDateTime)
        {
            return utcDateTime.ToUniversalTime().ToCentral();
        }

        /// <summary>
        /// Parse a utc time string to get the central timezone <see cref="DateTime"/>
        /// </summary>
        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the central timezone <see cref="DateTime"/>
        /// </summary>
        public static bool TryParse(string utcTime, out DateTime centralDateTime)
        {
            try
            {
                centralDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                centralDateTime = default(DateTime);
                return false;
            }
        }
    }
}
