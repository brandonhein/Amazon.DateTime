namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;


    public class CentralDateTime
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToCentral();
            }
        }

        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime);
            return result.ToCentral();
        }

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
