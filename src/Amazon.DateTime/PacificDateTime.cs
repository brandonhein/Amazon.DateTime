namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class PacificDateTime
    {
        /// <summary>
        /// Get the Current 'Now' time in Pacific Timezone
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToPacific();
            }
        }

        /// <summary>
        /// Get the Current 'Now' time in Pacific timezone as a string. 
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
                return Now.IsInDaylightSavingsTime() ? "-07:00" : "-08:00";
            }
        }

        /// <summary>
        /// Convert a utc <see cref="DateTime"/> value to the pacific timezone equivalent 
        /// </summary>
        public static DateTime Convert(DateTime utcDateTime)
        {
            return utcDateTime.ToUniversalTime().ToPacific();
        }

        /// <summary>
        /// Parse a utc time string to get the pacific timezone <see cref="DateTime"/>
        /// </summary>
        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime).ToUniversalTime();
            return result.ToPacific();
        }

        /// <summary>
        /// TryParse a utc time string to get the pacific timezone <see cref="DateTime"/>
        /// </summary>
        public static bool TryParse(string utcTime, out DateTime pacificDateTime)
        {
            try
            {
                pacificDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                pacificDateTime = default(DateTime);
                return false;
            }
        }
    }
}
