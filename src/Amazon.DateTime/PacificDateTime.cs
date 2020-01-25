namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class PacificDateTime
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToPacific();
            }
        }

        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime);
            return result.ToPacific();
        }

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
