namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class EasternDateTime 
    {
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
