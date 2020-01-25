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

        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime);
            return result.ToEastern();
        }

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
