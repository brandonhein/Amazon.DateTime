namespace Amazon.DateTime
{
    using System;

    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a eastern time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToEasternString(this DateTime dateTime)
        {
            var easternDate = dateTime.ToEastern();
            return string.Concat(easternDate.ToString(Format.StandardDateTime),
                easternDate.IsInDaylightSavingsTime() ? EasternDateTime.DaylightOffset : EasternDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a central time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToCentralString(this DateTime dateTime)
        {
            var centralDate = dateTime.ToCentral();
            return string.Concat(centralDate.ToString(Format.StandardDateTime),
                centralDate.IsInDaylightSavingsTime() ? CentralDateTime.DaylightOffset : CentralDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a mountain time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToMountainString(this DateTime dateTime)
        {
            var mountainDate = dateTime.ToMountain();
            return string.Concat(mountainDate.ToString(Format.StandardDateTime),
                mountainDate.IsInDaylightSavingsTime() ? MountainDateTime.DaylightOffset : MountainDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a pacific time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToPacificString(this DateTime dateTime)
        {
            var pacificDate = dateTime.ToPacific();
            return string.Concat(pacificDate.ToString(Format.StandardDateTime),
                pacificDate.IsInDaylightSavingsTime() ? PacificDateTime.DaylightOffset : PacificDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a alaska time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToAlaskaString(this DateTime dateTime)
        {
            var alaskaDate = dateTime.ToAlaska();
            return string.Concat(alaskaDate.ToString(Format.StandardDateTime),
                alaskaDate.IsInDaylightSavingsTime() ? AlaskaDateTime.DaylightOffset : AlaskaDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a hawaii time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToHawaiiString(this DateTime dateTime)
        {
            var hawaiiDate = dateTime.ToHawaii();
            return string.Concat(hawaiiDate.ToString(Format.StandardDateTime),
                hawaiiDate.IsInDaylightSavingsTime() ? HawaiiDateTime.DaylightOffset : HawaiiDateTime.StandardOffset);
        }
    }

    public static class Compare
    {
        public static int Dates(DateTimeBase t1, DateTimeBase t2)
        {
            return Dates(t1.ToUniversalTime(), t2.ToUniversalTime());
        }

        public static int Dates(DateTime t1, DateTime t2)
        {
            return DateTime.Compare(t1, t2);
        }
    }
}
