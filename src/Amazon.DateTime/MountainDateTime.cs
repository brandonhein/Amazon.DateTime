namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
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

        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime);
            return result.ToMountain();
        }

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
