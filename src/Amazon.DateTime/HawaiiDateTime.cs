namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class HawaiiDateTime
    {
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

        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime);
            return result.ToEastern();
        }

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
