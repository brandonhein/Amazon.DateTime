namespace Amazon.DateTime
{
    using Amazon.DateTime.Calculators;
    using System;

    public class AlaskaDateTime
    {
        /// <summary>
        /// Get the Current 'Now' time in Alaska
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.ToAlaska();
            }
        }

        public static DateTime Parse(string utcTime)
        {
            var result = DateTime.Parse(utcTime);
            return result.ToAlaska();
        }

        public static bool TryParse(string utcTime, out DateTime alaskaDateTime)
        {
            try
            {
                alaskaDateTime = Parse(utcTime);
                return true;
            }
            catch (Exception ex)
            {
                alaskaDateTime = default(DateTime);
                return false;
            }
        }
    }
}
