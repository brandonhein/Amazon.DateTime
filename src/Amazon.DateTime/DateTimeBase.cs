namespace Amazon.DateTime
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    public abstract class DateTimeBase : IEquatable<DateTimeBase>
    {
        protected DateTimeBase()
        { }

        [XmlIgnore]
        [IgnoreDataMember]
        public long Ticks { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Second { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public DateTime Date { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Month { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Minute { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Millisecond { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Hour { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int DayOfYear { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public DayOfWeek DayOfWeek { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Day { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public TimeSpan TimeOfDay { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public int Year { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        public string Offset { get; protected set; }

        [XmlText]
        [DataMember]
        public string Value
        {
            get
            {
                return string.Concat(Year.ToString("0000"), "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("000"), Offset);
            }
        }

        /// <summary>
        /// Converts the value of the current DateTimeBase object to Coordinated Universal Time (UTC)
        /// </summary>
        /// <returns></returns>
        public DateTime ToUniversalTime()
        {
            return DateTime.Parse(Value).ToUniversalTime();
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DateTimeBase);
        }

        public bool Equals(DateTimeBase other)
        {
            return other != null &&
                   Ticks == other.Ticks &&
                   Second == other.Second &&
                   Date == other.Date &&
                   Month == other.Month &&
                   Minute == other.Minute &&
                   Millisecond == other.Millisecond &&
                   Hour == other.Hour &&
                   DayOfYear == other.DayOfYear &&
                   DayOfWeek == other.DayOfWeek &&
                   Day == other.Day &&
                   TimeOfDay.Equals(other.TimeOfDay) &&
                   Year == other.Year &&
                   Offset == other.Offset &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hashCode = 844321305;
            hashCode = hashCode * -1521134295 + Ticks.GetHashCode();
            hashCode = hashCode * -1521134295 + Second.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + Minute.GetHashCode();
            hashCode = hashCode * -1521134295 + Millisecond.GetHashCode();
            hashCode = hashCode * -1521134295 + Hour.GetHashCode();
            hashCode = hashCode * -1521134295 + DayOfYear.GetHashCode();
            hashCode = hashCode * -1521134295 + DayOfWeek.GetHashCode();
            hashCode = hashCode * -1521134295 + Day.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TimeSpan>.Default.GetHashCode(TimeOfDay);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Offset);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        /// <summary>
        /// D1 is equal to D2
        /// </summary>
        public static bool operator ==(DateTimeBase d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) == 0;
        }

        /// <summary>
        /// D1 is equal to D2
        /// </summary>
        public static bool operator ==(DateTime d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) == 0;
        }

        /// <summary>
        /// D1 is equal to D2
        /// </summary>
        public static bool operator ==(DateTimeBase d1, DateTime d2)
        {
            return Compare.Dates(d1, d2) == 0;
        }

        /// <summary>
        /// D1 is not equal to D2
        /// </summary>
        public static bool operator !=(DateTimeBase d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) != 0;
        }

        /// <summary>
        /// D1 is not equal to D2
        /// </summary>
        public static bool operator !=(DateTime d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) != 0;
        }

        /// <summary>
        /// D1 is not equal to D2
        /// </summary>
        public static bool operator !=(DateTimeBase d1, DateTime d2)
        {
            return Compare.Dates(d1, d2) != 0;
        }

        /// <summary>
        /// D1 is earlier than D2
        /// <para>D2 is later than D1</para>
        /// </summary>
        public static bool operator <(DateTimeBase d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) < 0;
        }

        /// <summary>
        /// D1 is earlier than D2
        /// <para>D2 is later than D1</para>
        /// </summary>
        public static bool operator <(DateTime d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) < 0;
        }

        /// <summary>
        /// D1 is earlier than D2
        /// <para>D2 is later than D1</para>
        /// </summary>
        public static bool operator <(DateTimeBase d1, DateTime d2)
        {
            return Compare.Dates(d1, d2) < 0;
        }

        /// <summary>
        /// D1 is later than D2
        /// <para>D2 is earlier than D1</para>
        /// </summary>
        public static bool operator >(DateTimeBase d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) > 0;
        }

        /// <summary>
        /// D1 is later than D2
        /// <para>D2 is earlier than D1</para>
        /// </summary>
        public static bool operator >(DateTime d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) > 0;
        }

        /// <summary>
        /// D1 is later than D2
        /// <para>D2 is earlier than D1</para>
        /// </summary>
        public static bool operator >(DateTimeBase d1, DateTime d2)
        {
            return Compare.Dates(d1, d2) > 0;
        }

        /// <summary>
        /// D1 is earlier or the same as D2
        /// <para>D2 is later or the same as D1</para>
        /// </summary>
        public static bool operator <=(DateTimeBase d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) <= 0;
        }

        /// <summary>
        /// D1 is earlier or thae same as D2
        /// <para>D2 is later or the same as D1</para>
        /// </summary>
        public static bool operator <=(DateTime d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) <= 0;
        }

        /// <summary>
        /// D1 is earlier or the same as D2
        /// <para>D2 is later or the same as D1</para>
        /// </summary>
        public static bool operator <=(DateTimeBase d1, DateTime d2)
        {
            return Compare.Dates(d1, d2) <= 0;
        }

        /// <summary>
        /// D1 is later or the same as D2
        /// D2 is earlier or the same as D1
        /// <para>D2 is earlier or the same as D1</para>
        /// </summary>
        public static bool operator >=(DateTimeBase d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) >= 0;
        }

        /// <summary>
        /// D1 is later or the same as D2
        /// D2 is earlier or the same as D1
        /// <para>D2 is earlier or the same as D1</para>
        /// </summary>
        public static bool operator >=(DateTime d1, DateTimeBase d2)
        {
            return Compare.Dates(d1, d2) >= 0;
        }

        /// <summary>
        /// D1 is later or the same as D2
        /// D2 is earlier or the same as D1
        /// <para>D2 is earlier or the same as D1</para>
        /// </summary>
        public static bool operator >=(DateTimeBase d1, DateTime d2)
        {
            return Compare.Dates(d1, d2) >= 0;
        }
    }
}
