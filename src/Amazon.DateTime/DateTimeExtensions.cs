namespace Amazon.DateTime
{
    using System;

    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a eastern time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToEasternString(this DateTime dateTime, bool observesDaylightSavings = true)
        {
            var easternDate = dateTime.ToEastern();
            return string.Concat(easternDate.ToString(Format.StandardDateTime),
                observesDaylightSavings && easternDate.IsInDaylightSavingsTime() ? EasternDateTime.DaylightOffset : EasternDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a central time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToCentralString(this DateTime dateTime, bool observesDaylightSavings = true)
        {
            var centralDate = dateTime.ToCentral();
            return string.Concat(centralDate.ToString(Format.StandardDateTime),
                observesDaylightSavings && centralDate.IsInDaylightSavingsTime() ? CentralDateTime.DaylightOffset : CentralDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a mountain time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToMountainString(this DateTime dateTime, bool observesDaylightSavings = true)
        {
            var mountainDate = dateTime.ToMountain();
            return string.Concat(mountainDate.ToString(Format.StandardDateTime),
                observesDaylightSavings && mountainDate.IsInDaylightSavingsTime() ? MountainDateTime.DaylightOffset : MountainDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a pacific time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToPacificString(this DateTime dateTime, bool observesDaylightSavings = true)
        {
            var pacificDate = dateTime.ToPacific();
            return string.Concat(pacificDate.ToString(Format.StandardDateTime),
                observesDaylightSavings && pacificDate.IsInDaylightSavingsTime() ? PacificDateTime.DaylightOffset : PacificDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a alaska time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToAlaskaString(this DateTime dateTime, bool observesDaylightSavings = true)
        {
            var alaskaDate = dateTime.ToAlaska();
            return string.Concat(alaskaDate.ToString(Format.StandardDateTime),
                observesDaylightSavings && alaskaDate.IsInDaylightSavingsTime() ? AlaskaDateTime.DaylightOffset : AlaskaDateTime.StandardOffset);
        }

        /// <summary>
        /// Converts a UTC <see cref="DateTime"/> to a hawaii time string format
        /// <para>FORMAT: yyyy-MM-ddTHH:mm:ss.fffzzz</para>
        /// </summary>
        public static string ToHawaiiString(this DateTime dateTime, bool observesDaylightSavings = false)
        {
            var hawaiiDate = dateTime.ToHawaii();
            return string.Concat(hawaiiDate.ToString(Format.StandardDateTime),
                observesDaylightSavings && hawaiiDate.IsInDaylightSavingsTime() ? HawaiiDateTime.DaylightOffset : HawaiiDateTime.StandardOffset);
        }
    }

    public static class Compare
    {
        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTimeBase t1, DateTimeBase t2)
        {
            return Dates(t1.ToUniversalTime(), t2.ToUniversalTime());
        }

        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTimeBase t1, DateTime t2)
        {
            return Dates(t1.ToUniversalTime(), t2.ToUniversalTime());
        }

        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTime t1, DateTimeBase t2)
        {
            return Dates(t1.ToUniversalTime(), t2.ToUniversalTime());
        }

        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTime t1, DateTime t2)
        {
            return DateTime.Compare(t1, t2);
        }
    }
}
