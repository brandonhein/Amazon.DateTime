namespace Amazon.DateTime
{
    using Amazon.DateTime.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(SystemTextDateTimeConverter))]
    public abstract class DateTimeBase : IEquatable<DateTimeBase>, IComparable<DateTimeBase>, IComparable<DateTime>, IEquatable<DateTime>
    {
        protected DateTimeBase()
        { }

        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public long Ticks => DateTimeOffset.Parse(Value).Ticks;
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Second { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTimeBase Date { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Month { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public MonthsOfYear MonthOfYear => (MonthsOfYear)Month;
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Minute { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Millisecond { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Hour { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int DayOfYear { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public DayOfWeek DayOfWeek { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Day { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public TimeSpan TimeOfDay => TimeSpan.Parse(string.Concat(Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00")));
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Year { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public TimeSpan Offset { get; protected set; }
        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Timezone Kind { get; protected set; }

        /// <summary>
        /// Indicates whether this instance of <see cref="DateTimeBase"/> is within the daylight saving time range for the current time zone.
        /// </summary>
        public bool IsDaylightSavingTime() => DateTimeOffset.Parse(Value).DateTime.IsInDaylightSavingsTime();

        ///<summary>
        ///Creates a timestamp of the format of 'yyyy-MM-ddTHH:mm:ss.fffzzz'
        ///<para>Sample: 2020-01-28T16:09:05.366-05:00</para>
        ///</summary>
        [XmlText]
        [DataMember]
        public string Value
        {
            get
            {
                var offset = string.Format("{0:00}:{1:00}", Offset.Hours, Offset.Minutes);
                if (!offset.StartsWith("-"))
                    offset = string.Concat("+", offset);
                return string.Concat(Year.ToString("0000"), "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("000"), offset);
            }
        }

        [XmlIgnore]
        [IgnoreDataMember]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        protected string UtcValue
        {
            get { return $"{ToUniversalTime().ToString(Format.StandardDateTime)}Z"; }
        }

        /// <summary>
        /// Converts the value of the current DateTimeBase object to Coordinated Universal Time (UTC)
        /// </summary>
        public DateTime ToUniversalTime()
            => ToDateTimeOffset().UtcDateTime;

        /// <summary>
        /// Converts the value of the current DateTimeBase object to a DateTime struct
        /// </summary>
        public DateTime ToDateTime()
            => ToDateTimeOffset().DateTime;

        /// <summary>
        /// Converts the value of the current DateTimeBase object to a DateTimeOffset struct
        /// </summary>
        public DateTimeOffset ToDateTimeOffset()
            => DateTimeOffset.Parse(Value);

        /// <summary>
        /// returns same string as the <see cref="Value"/> property
        /// </summary>
        public override string ToString() => Value;

        public string ToString(string format)
        {
            var dateTimeOffset = DateTimeOffset.Parse(Value);
            return dateTimeOffset.ToString(format);
        }

        public string ToString(IFormatProvider provider)
        {
            var dateTimeOffset = DateTimeOffset.Parse(Value);
            return dateTimeOffset.ToString(provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            var dateTimeOffset = DateTimeOffset.Parse(Value);
            return dateTimeOffset.ToString(format, provider);
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
            hashCode = hashCode * -1521134295 + EqualityComparer<TimeSpan>.Default.GetHashCode(Offset);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        public bool Equals(DateTime other) => this == other;

        public int CompareTo(DateTime other)
        {
            if (this < other)
                return -1;

            if (this > other)
                return 1;

            return 0;
        }

        public int CompareTo(DateTimeBase other)
        {
            if (this < other)
                return -1;

            if (this > other)
                return 1;

            return 0;
        }

        /// <summary>
        /// D1 is equal to D2
        /// </summary>
        public static bool operator ==(DateTimeBase d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) == 0;

        /// <summary>
        /// D1 is equal to D2
        /// </summary>
        public static bool operator ==(DateTime d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) == 0;

        /// <summary>
        /// D1 is equal to D2
        /// </summary>
        public static bool operator ==(DateTimeBase d1, DateTime d2)
            => DateTimeCompare.Dates(d1, d2) == 0;

        /// <summary>
        /// D1 is not equal to D2
        /// </summary>
        public static bool operator !=(DateTimeBase d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) != 0;

        /// <summary>
        /// D1 is not equal to D2
        /// </summary>
        public static bool operator !=(DateTime d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) != 0;

        /// <summary>
        /// D1 is not equal to D2
        /// </summary>
        public static bool operator !=(DateTimeBase d1, DateTime d2)
            => DateTimeCompare.Dates(d1, d2) != 0;

        /// <summary>
        /// D1 is earlier than D2
        /// <para>D2 is later than D1</para>
        /// </summary>
        public static bool operator <(DateTimeBase d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) < 0;

        /// <summary>
        /// D1 is earlier than D2
        /// <para>D2 is later than D1</para>
        /// </summary>
        public static bool operator <(DateTime d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) < 0;

        /// <summary>
        /// D1 is earlier than D2
        /// <para>D2 is later than D1</para>
        /// </summary>
        public static bool operator <(DateTimeBase d1, DateTime d2)
            => DateTimeCompare.Dates(d1, d2) < 0;

        /// <summary>
        /// D1 is later than D2
        /// <para>D2 is earlier than D1</para>
        /// </summary>
        public static bool operator >(DateTimeBase d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) > 0;

        /// <summary>
        /// D1 is later than D2
        /// <para>D2 is earlier than D1</para>
        /// </summary>
        public static bool operator >(DateTime d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) > 0;

        /// <summary>
        /// D1 is later than D2
        /// <para>D2 is earlier than D1</para>
        /// </summary>
        public static bool operator >(DateTimeBase d1, DateTime d2)
            => DateTimeCompare.Dates(d1, d2) > 0;

        /// <summary>
        /// D1 is earlier or the same as D2
        /// <para>D2 is later or the same as D1</para>
        /// </summary>
        public static bool operator <=(DateTimeBase d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) <= 0;

        /// <summary>
        /// D1 is earlier or thae same as D2
        /// <para>D2 is later or the same as D1</para>
        /// </summary>
        public static bool operator <=(DateTime d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) <= 0;

        /// <summary>
        /// D1 is earlier or the same as D2
        /// <para>D2 is later or the same as D1</para>
        /// </summary>
        public static bool operator <=(DateTimeBase d1, DateTime d2)
            => DateTimeCompare.Dates(d1, d2) <= 0;

        /// <summary>
        /// D1 is later or the same as D2
        /// D2 is earlier or the same as D1
        /// <para>D2 is earlier or the same as D1</para>
        /// </summary>
        public static bool operator >=(DateTimeBase d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) >= 0;

        /// <summary>
        /// D1 is later or the same as D2
        /// D2 is earlier or the same as D1
        /// <para>D2 is earlier or the same as D1</para>
        /// </summary>
        public static bool operator >=(DateTime d1, DateTimeBase d2)
            => DateTimeCompare.Dates(d1, d2) >= 0;

        /// <summary>
        /// D1 is later or the same as D2
        /// D2 is earlier or the same as D1
        /// <para>D2 is earlier or the same as D1</para>
        /// </summary>
        public static bool operator >=(DateTimeBase d1, DateTime d2)
            => DateTimeCompare.Dates(d1, d2) >= 0;
    }
}
