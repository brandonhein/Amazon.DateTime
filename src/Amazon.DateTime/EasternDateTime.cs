namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class EasternDateTime 
    {
        /// <summary>
        /// Get the Current 'Now' time in Eastern Timezone
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
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fff-{off:set}</para>
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
                return Now.IsInDaylightSavingsTime() ? "-04:00" : "-05:00";
            }
        }

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the eastern timezone equivalent 
        /// </summary>
        public static DateTime Convert(DateTime utcDateTime)
        {
            return utcDateTime.ToUniversalTime().ToEastern();
        }

        /// <summary>
        /// Parse a utc time string to get the eastern timezone <see cref="DateTime"/>
        /// </summary>
        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return Convert(result);
        }

        /// <summary>
        /// TryParse a utc time string to get the eastern timezone <see cref="DateTime"/>
        /// </summary>
        public static bool TryParse(string utcTime, out DateTime easternDateTime)
        {
            try
            {
                easternDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                easternDateTime = default(DateTime);
                return false;
            }
        }
    }
}
