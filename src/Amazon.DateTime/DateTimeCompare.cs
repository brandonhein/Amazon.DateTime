namespace Amazon.DateTime
{
    using System;

    public static class DateTimeCompare
    {
        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTimeBase t1, DateTimeBase t2)
            => Dates(t1.ToUniversalTime(), t2.ToUniversalTime());

        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTimeBase t1, DateTime t2)
            => Dates(t1.ToUniversalTime(), t2.ToUniversalTime());

        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTime t1, DateTimeBase t2)
            => Dates(t1.ToUniversalTime(), t2.ToUniversalTime());

        /// <summary>
        /// <para>IF result is less than 0; THEN t1 is earlier than t2</para>
        /// <para>IF result is 0; THEN t1 is the same as t2</para>
        /// <para>IF result is greater than 0; THEN t1 is later than t2</para>
        /// </summary>
        public static int Dates(DateTime t1, DateTime t2)
            => DateTime.Compare(t1, t2);
    }
}
