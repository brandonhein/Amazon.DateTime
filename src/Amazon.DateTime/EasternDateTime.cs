using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.DateTime
{
    public struct EasternDateTime
    {
        public static readonly System.DateTime MaxValue = System.DateTime.MaxValue;
        public static readonly System.DateTime MinValue = System.DateTime.MinValue;

        //
        // Summary:
        //     Represents the largest possible value of System.DateTime. This field is read-only.
        public static readonly DateTime MaxValue;
        //
        // Summary:
        //     Represents the smallest possible value of System.DateTime. This field is read-only.
        public static readonly DateTime MinValue;

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to a specified number
        //     of ticks.
        //
        // Parameters:
        //   ticks:
        //     A date and time expressed in the number of 100-nanosecond intervals that have
        //     elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     ticks is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        public DateTime(long ticks);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to a specified number
        //     of ticks and to Coordinated Universal Time (UTC) or local time.
        //
        // Parameters:
        //   ticks:
        //     A date and time expressed in the number of 100-nanosecond intervals that have
        //     elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar.
        //
        //   kind:
        //     One of the enumeration values that indicates whether ticks specifies a local
        //     time, Coordinated Universal Time (UTC), or neither.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     ticks is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public DateTime(long ticks, DateTimeKind kind);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, and day.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        public DateTime(int year, int month, int day);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, and day for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar. -or- month is less than 1 or
        //     greater than the number of months in calendar. -or- day is less than 1 or greater
        //     than the number of days in month.
        public DateTime(int year, int month, int day, Calendar calendar);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, and second.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        //     -or- hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59.
        public DateTime(int year, int month, int day, int hour, int minute, int second);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and Coordinated Universal Time (UTC)
        //     or local time.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   kind:
        //     One of the enumeration values that indicates whether year, month, day, hour,
        //     minute and second specify a local time, Coordinated Universal Time (UTC), or
        //     neither.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        //     -or- hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, and second for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar. -or- month is less than 1 or
        //     greater than the number of months in calendar. -or- day is less than 1 or greater
        //     than the number of days in month. -or- hour is less than 0 or greater than 23
        //     -or- minute is less than 0 or greater than 59. -or- second is less than 0 or
        //     greater than 59.
        public DateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and millisecond.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        //     -or- hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59. -or- millisecond is less
        //     than 0 or greater than 999.
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, millisecond, and Coordinated Universal
        //     Time (UTC) or local time.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        //   kind:
        //     One of the enumeration values that indicates whether year, month, day, hour,
        //     minute, second, and millisecond specify a local time, Coordinated Universal Time
        //     (UTC), or neither.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        //     -or- hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59. -or- millisecond is less
        //     than 0 or greater than 999.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and millisecond for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar. -or- month is less than 1 or
        //     greater than the number of months in calendar. -or- day is less than 1 or greater
        //     than the number of days in month. -or- hour is less than 0 or greater than 23.
        //     -or- minute is less than 0 or greater than 59. -or- second is less than 0 or
        //     greater than 59. -or- millisecond is less than 0 or greater than 999.
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar);
        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, millisecond, and Coordinated Universal
        //     Time (UTC) or local time for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        //   kind:
        //     One of the enumeration values that indicates whether year, month, day, hour,
        //     minute, second, and millisecond specify a local time, Coordinated Universal Time
        //     (UTC), or neither.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar. -or- month is less than 1 or
        //     greater than the number of months in calendar. -or- day is less than 1 or greater
        //     than the number of days in month. -or- hour is less than 0 or greater than 23.
        //     -or- minute is less than 0 or greater than 59. -or- second is less than 0 or
        //     greater than 59. -or- millisecond is less than 0 or greater than 999.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind);

        //
        // Summary:
        //     Gets a System.DateTime object that is set to the current date and time on this
        //     computer, expressed as the local time.
        //
        // Returns:
        //     An object whose value is the current local date and time.
        public static DateTime Now { get; }
        //
        // Summary:
        //     Gets the current date.
        //
        // Returns:
        //     An object that is set to today's date, with the time component set to 00:00:00.
        public static DateTime Today { get; }
        //
        // Summary:
        //     Gets a System.DateTime object that is set to the current date and time on this
        //     computer, expressed as the Coordinated Universal Time (UTC).
        //
        // Returns:
        //     An object whose value is the current UTC date and time.
        public static DateTime UtcNow { get; }
        //
        // Summary:
        //     Gets the number of ticks that represent the date and time of this instance.
        //
        // Returns:
        //     The number of ticks that represent the date and time of this instance. The value
        //     is between DateTime.MinValue.Ticks and DateTime.MaxValue.Ticks.
        public long Ticks { get; }
        //
        // Summary:
        //     Gets the seconds component of the date represented by this instance.
        //
        // Returns:
        //     The seconds component, expressed as a value between 0 and 59.
        public int Second { get; }
        //
        // Summary:
        //     Gets the date component of this instance.
        //
        // Returns:
        //     A new object with the same date as this instance, and the time value set to 12:00:00
        //     midnight (00:00:00).
        public DateTime Date { get; }
        //
        // Summary:
        //     Gets the month component of the date represented by this instance.
        //
        // Returns:
        //     The month component, expressed as a value between 1 and 12.
        public int Month { get; }
        //
        // Summary:
        //     Gets the minute component of the date represented by this instance.
        //
        // Returns:
        //     The minute component, expressed as a value between 0 and 59.
        public int Minute { get; }
        //
        // Summary:
        //     Gets the milliseconds component of the date represented by this instance.
        //
        // Returns:
        //     The milliseconds component, expressed as a value between 0 and 999.
        public int Millisecond { get; }
        //
        // Summary:
        //     Gets a value that indicates whether the time represented by this instance is
        //     based on local time, Coordinated Universal Time (UTC), or neither.
        //
        // Returns:
        //     One of the enumeration values that indicates what the current time represents.
        //     The default is System.DateTimeKind.Unspecified.
        public DateTimeKind Kind { get; }
        //
        // Summary:
        //     Gets the hour component of the date represented by this instance.
        //
        // Returns:
        //     The hour component, expressed as a value between 0 and 23.
        public int Hour { get; }
        //
        // Summary:
        //     Gets the day of the year represented by this instance.
        //
        // Returns:
        //     The day of the year, expressed as a value between 1 and 366.
        public int DayOfYear { get; }
        //
        // Summary:
        //     Gets the day of the week represented by this instance.
        //
        // Returns:
        //     An enumerated constant that indicates the day of the week of this System.DateTime
        //     value.
        public DayOfWeek DayOfWeek { get; }
        //
        // Summary:
        //     Gets the day of the month represented by this instance.
        //
        // Returns:
        //     The day component, expressed as a value between 1 and 31.
        public int Day { get; }
        //
        // Summary:
        //     Gets the time of day for this instance.
        //
        // Returns:
        //     A time interval that represents the fraction of the day that has elapsed since
        //     midnight.
        public TimeSpan TimeOfDay { get; }
        //
        // Summary:
        //     Gets the year component of the date represented by this instance.
        //
        // Returns:
        //     The year, between 1 and 9999.
        public int Year { get; }

        //
        public static int Compare(DateTime t1, DateTime t2);
        //
        // Summary:
        //     Returns the number of days in the specified month and year.
        //
        // Parameters:
        //   year:
        //     The year.
        //
        //   month:
        //     The month (a number ranging from 1 to 12).
        //
        // Returns:
        //     The number of days in month for the specified year. For example, if month equals
        //     2 for February, the return value is 28 or 29 depending upon whether year is a
        //     leap year.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     month is less than 1 or greater than 12. -or- year is less than 1 or greater
        //     than 9999.
        public static int DaysInMonth(int year, int month);
        //
        // Summary:
        //     Returns a value indicating whether two System.DateTime instances have the same
        //     date and time value.
        //
        // Parameters:
        //   t1:
        //     The first object to compare.
        //
        //   t2:
        //     The second object to compare.
        //
        // Returns:
        //     true if the two values are equal; otherwise, false.
        public static bool Equals(DateTime t1, DateTime t2);
        //
        // Summary:
        //     Deserializes a 64-bit binary value and recreates an original serialized System.DateTime
        //     object.
        //
        // Parameters:
        //   dateData:
        //     A 64-bit signed integer that encodes the System.DateTime.Kind property in a 2-bit
        //     field and the System.DateTime.Ticks property in a 62-bit field.
        //
        // Returns:
        //     An object that is equivalent to the System.DateTime object that was serialized
        //     by the System.DateTime.ToBinary method.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     dateData is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        public static DateTime FromBinary(long dateData);
        //
        // Summary:
        //     Converts the specified Windows file time to an equivalent local time.
        //
        // Parameters:
        //   fileTime:
        //     A Windows file time expressed in ticks.
        //
        // Returns:
        //     An object that represents the local time equivalent of the date and time represented
        //     by the fileTime parameter.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     fileTime is less than 0 or represents a time greater than System.DateTime.MaxValue.
        public static DateTime FromFileTime(long fileTime);
        //
        // Summary:
        //     Converts the specified Windows file time to an equivalent UTC time.
        //
        // Parameters:
        //   fileTime:
        //     A Windows file time expressed in ticks.
        //
        // Returns:
        //     An object that represents the UTC time equivalent of the date and time represented
        //     by the fileTime parameter.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     fileTime is less than 0 or represents a time greater than System.DateTime.MaxValue.
        public static DateTime FromFileTimeUtc(long fileTime);
        //
        // Summary:
        //     Returns a System.DateTime equivalent to the specified OLE Automation Date.
        //
        // Parameters:
        //   d:
        //     An OLE Automation Date value.
        //
        // Returns:
        //     An object that represents the same date and time as d.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The date is not a valid OLE Automation Date value.
        public static DateTime FromOADate(double d);
        //
        // Summary:
        //     Returns an indication whether the specified year is a leap year.
        //
        // Parameters:
        //   year:
        //     A 4-digit year.
        //
        // Returns:
        //     true if year is a leap year; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999.
        public static bool IsLeapYear(int year);
        //
        // Summary:
        //     Converts the string representation of a date and time to its System.DateTime
        //     equivalent by using culture-specific format information and formatting style.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   styles:
        //     A bitwise combination of the enumeration values that indicates the style elements
        //     that can be present in s for the parse operation to succeed, and that defines
        //     how to interpret the parsed date in relation to the current time zone or the
        //     current date. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by provider and styles.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s does not contain a valid string representation of a date and time.
        //
        //   T:System.ArgumentException:
        //     styles contains an invalid combination of System.Globalization.DateTimeStyles
        //     values. For example, both System.Globalization.DateTimeStyles.AssumeLocal and
        //     System.Globalization.DateTimeStyles.AssumeUniversal.
        public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles);
        //
        // Summary:
        //     Converts the string representation of a date and time to its System.DateTime
        //     equivalent by using culture-specific format information.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s as specified
        //     by provider.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s does not contain a valid string representation of a date and time.
        public static DateTime Parse(string s, IFormatProvider provider);
        //
        // Summary:
        //     Converts the string representation of a date and time to its System.DateTime
        //     equivalent.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s does not contain a valid string representation of a date and time.
        public static DateTime Parse(string s);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified array of formats, culture-specific format information,
        //     and style. The format of the string representation must match at least one of
        //     the specified formats exactly or an exception is thrown.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   formats:
        //     An array of allowable formats of s. For more information, see the Remarks section.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        //   style:
        //     A bitwise combination of enumeration values that indicates the permitted format
        //     of s. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by formats, provider, and style.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s or formats is null.
        //
        //   T:System.FormatException:
        //     s is an empty string. -or- an element of formats is an empty string. -or- s does
        //     not contain a date and time that corresponds to any element of formats. -or-
        //     The hour component and the AM/PM designator in s do not agree.
        //
        //   T:System.ArgumentException:
        //     style contains an invalid combination of System.Globalization.DateTimeStyles
        //     values. For example, both System.Globalization.DateTimeStyles.AssumeLocal and
        //     System.Globalization.DateTimeStyles.AssumeUniversal.
        public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified format, culture-specific format information, and
        //     style. The format of the string representation must match the specified format
        //     exactly or an exception is thrown.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   format:
        //     A format specifier that defines the required format of s. For more information,
        //     see the Remarks section.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   style:
        //     A bitwise combination of the enumeration values that provides additional information
        //     about s, about style elements that may be present in s, or about the conversion
        //     from s to a System.DateTime value. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by format, provider, and style.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s or format is null.
        //
        //   T:System.FormatException:
        //     s or format is an empty string. -or- s does not contain a date and time that
        //     corresponds to the pattern specified in format. -or- The hour component and the
        //     AM/PM designator in s do not agree.
        //
        //   T:System.ArgumentException:
        //     style contains an invalid combination of System.Globalization.DateTimeStyles
        //     values. For example, both System.Globalization.DateTimeStyles.AssumeLocal and
        //     System.Globalization.DateTimeStyles.AssumeUniversal.
        public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified format and culture-specific format information.
        //     The format of the string representation must match the specified format exactly.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   format:
        //     A format specifier that defines the required format of s. For more information,
        //     see the Remarks section.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by format and provider.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s or format is null.
        //
        //   T:System.FormatException:
        //     s or format is an empty string. -or- s does not contain a date and time that
        //     corresponds to the pattern specified in format. -or- The hour component and the
        //     AM/PM designator in s do not agree.
        public static DateTime ParseExact(string s, string format, IFormatProvider provider);
        //
        // Summary:
        //     Creates a new System.DateTime object that has the same number of ticks as the
        //     specified System.DateTime, but is designated as either local time, Coordinated
        //     Universal Time (UTC), or neither, as indicated by the specified System.DateTimeKind
        //     value.
        //
        // Parameters:
        //   value:
        //     A date and time.
        //
        //   kind:
        //     One of the enumeration values that indicates whether the new object represents
        //     local time, UTC, or neither.
        //
        // Returns:
        //     A new object that has the same number of ticks as the object represented by the
        //     value parameter and the System.DateTimeKind value specified by the kind parameter.
        public static DateTime SpecifyKind(DateTime value, DateTimeKind kind);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified culture-specific format information and formatting
        //     style, and returns a value that indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   styles:
        //     A bitwise combination of enumeration values that defines how to interpret the
        //     parsed date in relation to the current time zone or the current date. A typical
        //     value to specify is System.Globalization.DateTimeStyles.None.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if the s parameter is null, is
        //     an empty string (""), or does not contain a valid string representation of a
        //     date and time. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if the s parameter was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     styles is not a valid System.Globalization.DateTimeStyles value. -or- styles
        //     contains an invalid combination of System.Globalization.DateTimeStyles values
        //     (for example, both System.Globalization.DateTimeStyles.AssumeLocal and System.Globalization.DateTimeStyles.AssumeUniversal).
        //
        //   T:System.NotSupportedException:
        //     provider is a neutral culture and cannot be used in a parsing operation.
        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent and returns a value that indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if the s parameter is null, is
        //     an empty string (""), or does not contain a valid string representation of a
        //     date and time. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if the s parameter was converted successfully; otherwise, false.
        public static bool TryParse(string s, out DateTime result);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified format, culture-specific format information, and
        //     style. The format of the string representation must match the specified format
        //     exactly. The method returns a value that indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   format:
        //     The required format of s.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   style:
        //     A bitwise combination of one or more enumeration values that indicate the permitted
        //     format of s.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if either the s or format parameter
        //     is null, is an empty string, or does not contain a date and time that correspond
        //     to the pattern specified in format. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if s was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     styles is not a valid System.Globalization.DateTimeStyles value. -or- styles
        //     contains an invalid combination of System.Globalization.DateTimeStyles values
        //     (for example, both System.Globalization.DateTimeStyles.AssumeLocal and System.Globalization.DateTimeStyles.AssumeUniversal).
        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified array of formats, culture-specific format information,
        //     and style. The format of the string representation must match at least one of
        //     the specified formats exactly. The method returns a value that indicates whether
        //     the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   formats:
        //     An array of allowable formats of s.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        //   style:
        //     A bitwise combination of enumeration values that indicates the permitted format
        //     of s. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if s or formats is null, s or
        //     an element of formats is an empty string, or the format of s is not exactly as
        //     specified by at least one of the format patterns in formats. This parameter is
        //     passed uninitialized.
        //
        // Returns:
        //     true if the s parameter was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     styles is not a valid System.Globalization.DateTimeStyles value. -or- styles
        //     contains an invalid combination of System.Globalization.DateTimeStyles values
        //     (for example, both System.Globalization.DateTimeStyles.AssumeLocal and System.Globalization.DateTimeStyles.AssumeUniversal).
        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the value of the specified System.TimeSpan
        //     to the value of this instance.
        //
        // Parameters:
        //   value:
        //     A positive or negative time interval.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the time interval represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime Add(TimeSpan value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of days to the value
        //     of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional days. The value parameter can be negative or
        //     positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of days represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddDays(double value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of hours to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional hours. The value parameter can be negative or
        //     positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of hours represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddHours(double value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of milliseconds
        //     to the value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional milliseconds. The value parameter can be negative
        //     or positive. Note that this value is rounded to the nearest integer.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of milliseconds represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddMilliseconds(double value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of minutes to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional minutes. The value parameter can be negative
        //     or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of minutes represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddMinutes(double value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of months to the
        //     value of this instance.
        //
        // Parameters:
        //   months:
        //     A number of months. The months parameter can be negative or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and months.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue. -or- months is less than -120,000 or greater than
        //     120,000.
        public DateTime AddMonths(int months);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of seconds to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional seconds. The value parameter can be negative
        //     or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of seconds represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddSeconds(double value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of ticks to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of 100-nanosecond ticks. The value parameter can be positive or negative.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the time represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddTicks(long value);
        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of years to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of years. The value parameter can be negative or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of years represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     value or the resulting System.DateTime is less than System.DateTime.MinValue
        //     or greater than System.DateTime.MaxValue.
        public DateTime AddYears(int value);
        //
        public int CompareTo(DateTime value);
        //
        public int CompareTo(object value);
        //
        // Summary:
        //     Returns a value indicating whether this instance is equal to a specified object.
        //
        // Parameters:
        //   value:
        //     The object to compare to this instance.
        //
        // Returns:
        //     true if value is an instance of System.DateTime and equals the value of this
        //     instance; otherwise, false.
        public override bool Equals(object value);
        //
        // Summary:
        //     Returns a value indicating whether the value of this instance is equal to the
        //     value of the specified System.DateTime instance.
        //
        // Parameters:
        //   value:
        //     The object to compare to this instance.
        //
        // Returns:
        //     true if the value parameter equals the value of this instance; otherwise, false.
        public bool Equals(DateTime value);
        //
        // Summary:
        //     Converts the value of this instance to all the string representations supported
        //     by the specified standard date and time format specifier and culture-specific
        //     formatting information.
        //
        // Parameters:
        //   format:
        //     A date and time format string.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about this instance.
        //
        // Returns:
        //     A string array where each element is the representation of the value of this
        //     instance formatted with one of the standard date and time format specifiers.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     format is not a valid standard date and time format specifier character.
        public string[] GetDateTimeFormats(char format, IFormatProvider provider);
        //
        // Summary:
        //     Converts the value of this instance to all the string representations supported
        //     by the specified standard date and time format specifier.
        //
        // Parameters:
        //   format:
        //     A standard date and time format string.
        //
        // Returns:
        //     A string array where each element is the representation of the value of this
        //     instance formatted with the format standard date and time format specifier.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     format is not a valid standard date and time format specifier character.
        public string[] GetDateTimeFormats(char format);
        //
        // Summary:
        //     Converts the value of this instance to all the string representations supported
        //     by the standard date and time format specifiers.
        //
        // Returns:
        //     A string array where each element is the representation of the value of this
        //     instance formatted with one of the standard date and time format specifiers.
        public string[] GetDateTimeFormats();
        //
        // Summary:
        //     Converts the value of this instance to all the string representations supported
        //     by the standard date and time format specifiers and the specified culture-specific
        //     formatting information.
        //
        // Parameters:
        //   provider:
        //     An object that supplies culture-specific formatting information about this instance.
        //
        // Returns:
        //     A string array where each element is the representation of the value of this
        //     instance formatted with one of the standard date and time format specifiers.
        public string[] GetDateTimeFormats(IFormatProvider provider);
        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     A 32-bit signed integer hash code.
        public override int GetHashCode();
        //
        // Summary:
        //     Returns the System.TypeCode for value type System.DateTime.
        //
        // Returns:
        //     The enumerated constant, System.TypeCode.DateTime.
        public TypeCode GetTypeCode();
        //
        // Summary:
        //     Indicates whether this instance of System.DateTime is within the daylight saving
        //     time range for the current time zone.
        //
        // Returns:
        //     true if the value of the System.DateTime.Kind property is System.DateTimeKind.Local
        //     or System.DateTimeKind.Unspecified and the value of this instance of System.DateTime
        //     is within the daylight saving time range for the local time zone; false if System.DateTime.Kind
        //     is System.DateTimeKind.Utc.
        public bool IsDaylightSavingTime();
        //
        // Summary:
        //     Subtracts the specified date and time from this instance.
        //
        // Parameters:
        //   value:
        //     The date and time value to subtract.
        //
        // Returns:
        //     A time interval that is equal to the date and time represented by this instance
        //     minus the date and time represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The result is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        public TimeSpan Subtract(DateTime value);
        //
        // Summary:
        //     Subtracts the specified duration from this instance.
        //
        // Parameters:
        //   value:
        //     The time interval to subtract.
        //
        // Returns:
        //     An object that is equal to the date and time represented by this instance minus
        //     the time interval represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The result is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        public DateTime Subtract(TimeSpan value);
        //
        // Summary:
        //     Serializes the current System.DateTime object to a 64-bit binary value that subsequently
        //     can be used to recreate the System.DateTime object.
        //
        // Returns:
        //     A 64-bit signed integer that encodes the System.DateTime.Kind and System.DateTime.Ticks
        //     properties.
        public long ToBinary();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to a Windows file time.
        //
        // Returns:
        //     The value of the current System.DateTime object expressed as a Windows file time.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting file time would represent a date and time before 12:00 midnight
        //     January 1, 1601 C.E. UTC.
        public long ToFileTime();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to a Windows file time.
        //
        // Returns:
        //     The value of the current System.DateTime object expressed as a Windows file time.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting file time would represent a date and time before 12:00 midnight
        //     January 1, 1601 C.E. UTC.
        public long ToFileTimeUtc();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to local time.
        //
        // Returns:
        //     An object whose System.DateTime.Kind property is System.DateTimeKind.Local, and
        //     whose value is the local time equivalent to the value of the current System.DateTime
        //     object, or System.DateTime.MaxValue if the converted value is too large to be
        //     represented by a System.DateTime object, or System.DateTime.MinValue if the converted
        //     value is too small to be represented as a System.DateTime object.
        public DateTime ToLocalTime();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent long
        //     date string representation.
        //
        // Returns:
        //     A string that contains the long date string representation of the current System.DateTime
        //     object.
        public string ToLongDateString();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent long
        //     time string representation.
        //
        // Returns:
        //     A string that contains the long time string representation of the current System.DateTime
        //     object.
        public string ToLongTimeString();
        //
        // Summary:
        //     Converts the value of this instance to the equivalent OLE Automation date.
        //
        // Returns:
        //     A double-precision floating-point number that contains an OLE Automation date
        //     equivalent to the value of this instance.
        //
        // Exceptions:
        //   T:System.OverflowException:
        //     The value of this instance cannot be represented as an OLE Automation Date.
        public double ToOADate();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent short
        //     date string representation.
        //
        // Returns:
        //     A string that contains the short date string representation of the current System.DateTime
        //     object.
        public string ToShortDateString();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent short
        //     time string representation.
        //
        // Returns:
        //     A string that contains the short time string representation of the current System.DateTime
        //     object.
        public string ToShortTimeString();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the specified format and the formatting conventions of the
        //     current culture.
        //
        // Parameters:
        //   format:
        //     A standard or custom date and time format string.
        //
        // Returns:
        //     A string representation of value of the current System.DateTime object as specified
        //     by format.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     The length of format is 1, and it is not one of the format specifier characters
        //     defined for System.Globalization.DateTimeFormatInfo. -or- format does not contain
        //     a valid custom format pattern.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by the current culture.
        public string ToString(string format);
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the specified culture-specific format information.
        //
        // Parameters:
        //   provider:
        //     An object that supplies culture-specific formatting information.
        //
        // Returns:
        //     A string representation of value of the current System.DateTime object as specified
        //     by provider.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by provider.
        public string ToString(IFormatProvider provider);
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the formatting conventions of the current culture.
        //
        // Returns:
        //     A string representation of the value of the current System.DateTime object.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by the current culture.
        public override string ToString();
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the specified format and culture-specific format information.
        //
        // Parameters:
        //   format:
        //     A standard or custom date and time format string.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information.
        //
        // Returns:
        //     A string representation of value of the current System.DateTime object as specified
        //     by format and provider.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     The length of format is 1, and it is not one of the format specifier characters
        //     defined for System.Globalization.DateTimeFormatInfo. -or- format does not contain
        //     a valid custom format pattern.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by provider.
        public string ToString(string format, IFormatProvider provider);
        //
        // Summary:
        //     Converts the value of the current System.DateTime object to Coordinated Universal
        //     Time (UTC).
        //
        // Returns:
        //     An object whose System.DateTime.Kind property is System.DateTimeKind.Utc, and
        //     whose value is the UTC equivalent to the value of the current System.DateTime
        //     object, or System.DateTime.MaxValue if the converted value is too large to be
        //     represented by a System.DateTime object, or System.DateTime.MinValue if the converted
        //     value is too small to be represented by a System.DateTime object.
        public DateTime ToUniversalTime();

        //
        // Summary:
        //     Adds a specified time interval to a specified date and time, yielding a new date
        //     and time.
        //
        // Parameters:
        //   d:
        //     The date and time value to add.
        //
        //   t:
        //     The time interval to add.
        //
        // Returns:
        //     An object that is the sum of the values of d and t.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public static DateTime operator +(DateTime d, TimeSpan t);
        //
        // Summary:
        //     Subtracts a specified date and time from another specified date and time and
        //     returns a time interval.
        //
        // Parameters:
        //   d1:
        //     The date and time value to subtract from (the minuend).
        //
        //   d2:
        //     The date and time value to subtract (the subtrahend).
        //
        // Returns:
        //     The time interval between d1 and d2; that is, d1 minus d2.
        public static TimeSpan operator -(DateTime d1, DateTime d2);
        //
        // Summary:
        //     Subtracts a specified time interval from a specified date and time and returns
        //     a new date and time.
        //
        // Parameters:
        //   d:
        //     The date and time value to subtract from.
        //
        //   t:
        //     The time interval to subtract.
        //
        // Returns:
        //     An object whose value is the value of d minus the value of t.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public static DateTime operator -(DateTime d, TimeSpan t);
        //
        // Summary:
        //     Determines whether two specified instances of System.DateTime are equal.
        //
        // Parameters:
        //   d1:
        //     The first object to compare.
        //
        //   d2:
        //     The second object to compare.
        //
        // Returns:
        //     true if d1 and d2 represent the same date and time; otherwise, false.
        public static bool operator ==(DateTime d1, DateTime d2);
        //
        // Summary:
        //     Determines whether two specified instances of System.DateTime are not equal.
        //
        // Parameters:
        //   d1:
        //     The first object to compare.
        //
        //   d2:
        //     The second object to compare.
        //
        // Returns:
        //     true if d1 and d2 do not represent the same date and time; otherwise, false.
        public static bool operator !=(DateTime d1, DateTime d2);
        //
        // Summary:
        //     Determines whether one specified System.DateTime is earlier than another specified
        //     System.DateTime.
        //
        // Parameters:
        //   t1:
        //     The first object to compare.
        //
        //   t2:
        //     The second object to compare.
        //
        // Returns:
        //     true if t1 is earlier than t2; otherwise, false.
        public static bool operator <(DateTime t1, DateTime t2);
        //
        // Summary:
        //     Determines whether one specified System.DateTime is later than another specified
        //     System.DateTime.
        //
        // Parameters:
        //   t1:
        //     The first object to compare.
        //
        //   t2:
        //     The second object to compare.
        //
        // Returns:
        //     true if t1 is later than t2; otherwise, false.
        public static bool operator >(DateTime t1, DateTime t2);
        //
        // Summary:
        //     Determines whether one specified System.DateTime represents a date and time that
        //     is the same as or earlier than another specified System.DateTime.
        //
        // Parameters:
        //   t1:
        //     The first object to compare.
        //
        //   t2:
        //     The second object to compare.
        //
        // Returns:
        //     true if t1 is the same as or earlier than t2; otherwise, false.
        public static bool operator <=(DateTime t1, DateTime t2);
        //
        // Summary:
        //     Determines whether one specified System.DateTime represents a date and time that
        //     is the same as or later than another specified System.DateTime.
        //
        // Parameters:
        //   t1:
        //     The first object to compare.
        //
        //   t2:
        //     The second object to compare.
        //
        // Returns:
        //     true if t1 is the same as or later than t2; otherwise, false.
        public static bool operator >=(DateTime t1, DateTime t2);
    }
}
