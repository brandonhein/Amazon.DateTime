namespace Amazon.DateTime
{
    using System;
    using System.Xml.Serialization;

    public abstract class DateTimeBase
    {
        protected DateTimeBase()
        { }

        [XmlIgnore]
        public long Ticks { get; protected set; }
        [XmlIgnore]
        public int Second { get; protected set; }
        [XmlIgnore]
        public DateTime Date { get; protected set; }
        [XmlIgnore]
        public int Month { get; protected set; }
        [XmlIgnore]
        public int Minute { get; protected set; }
        [XmlIgnore]
        public int Millisecond { get; protected set; }
        [XmlIgnore]
        public int Hour { get; protected set; }
        [XmlIgnore]
        public int DayOfYear { get; protected set; }
        [XmlIgnore]
        public DayOfWeek DayOfWeek { get; protected set; }
        [XmlIgnore]
        public int Day { get; protected set; }
        [XmlIgnore]
        public TimeSpan TimeOfDay { get; protected set; }
        [XmlIgnore]
        public int Year { get; protected set; }
        [XmlIgnore]
        public string Offset { get; protected set; }

        [XmlText]
        public string Value
        {
            get
            {
                return string.Concat(Year.ToString("0000"), "-", Month.ToString("00"), "-", Day.ToString("00"), "T", Hour.ToString("00"), ":", Minute.ToString("00"), ":", Second.ToString("00"), ".", Millisecond.ToString("000"), Offset);
            }
        }

        public DateTime ToUniversalTime()
        {
            return DateTime.Parse(Value).ToUniversalTime();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
