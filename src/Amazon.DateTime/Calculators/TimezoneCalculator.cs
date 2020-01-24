using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.DateTime.Calculators
{
    public static class TimezoneCalculator
    {
        private static Dictionary<Timezone, TimeZoneInfo> _selfGenTimezones;
        private static System.DateTime _selfSetDate;

        public static TimeZoneInfo GetTimezoneByCode(this TimeZoneInfo tz, Timezone timezone)
        {
            if (timezone != default(Timezone))
            {
                return null;
            }

            try
            {
                return Get(timezone);
            }
            catch (TimeZoneNotFoundException ex)
            {
                GenerateSelfTimezones();
                return _selfGenTimezones.FirstOrDefault(x => x.Key == timezone).Value;
            }
        }

        private static void GenerateSelfTimezones()
        {
            if (_selfGenTimezones == null)
            {
                _selfSetDate = System.DateTime.Now;
                _selfGenTimezones = new Dictionary<Timezone, TimeZoneInfo>();
                if (_selfSetDate.IsInDaylightSavingsTime())
                {
                    _selfGenTimezones.Add(Timezone.Eastern, TimeZoneInfo.CreateCustomTimeZone("Eastern Standard Time", TimeSpan.Parse("-04:00"), "Eastern Standard Time", "Eastern Standard Time"));
                    _selfGenTimezones.Add(Timezone.Central, TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", TimeSpan.Parse("-05:00"), "Central Standard Time", "Central Standard Time"));
                    _selfGenTimezones.Add(Timezone.Mountain, TimeZoneInfo.CreateCustomTimeZone("Mountain Standard Time", TimeSpan.Parse("-06:00"), "Mountain Standard Time", "Mountain Standard Time"));
                    _selfGenTimezones.Add(Timezone.Pacific, TimeZoneInfo.CreateCustomTimeZone("Pacific Standard Time", TimeSpan.Parse("-07:00"), "Pacific Standard Time", "Pacific Standard Time"));
                    _selfGenTimezones.Add(Timezone.Alaska, TimeZoneInfo.CreateCustomTimeZone("Alaskan Standard Time", TimeSpan.Parse("-08:00"), "Alaskan Standard Time", "Alaskan Standard Time"));
                }
                else
                {
                    _selfGenTimezones.Add(Timezone.Eastern, TimeZoneInfo.CreateCustomTimeZone("Eastern Standard Time", TimeSpan.Parse("-05:00"), "Eastern Standard Time", "Eastern Standard Time"));
                    _selfGenTimezones.Add(Timezone.Central, TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", TimeSpan.Parse("-06:00"), "Central Standard Time", "Central Standard Time"));
                    _selfGenTimezones.Add(Timezone.Mountain, TimeZoneInfo.CreateCustomTimeZone("Mountain Standard Time", TimeSpan.Parse("-07:00"), "Mountain Standard Time", "Mountain Standard Time"));
                    _selfGenTimezones.Add(Timezone.Pacific, TimeZoneInfo.CreateCustomTimeZone("Pacific Standard Time", TimeSpan.Parse("-08:00"), "Pacific Standard Time", "Pacific Standard Time"));
                    _selfGenTimezones.Add(Timezone.Alaska, TimeZoneInfo.CreateCustomTimeZone("Alaskan Standard Time", TimeSpan.Parse("-09:00"), "Alaskan Standard Time", "Alaskan Standard Time"));
                }

                _selfGenTimezones.Add(Timezone.Hawaii, TimeZoneInfo.CreateCustomTimeZone("Hawaiian Standard Time", TimeSpan.Parse("-10:00"), "Hawaiian Standard Time", "Hawaiian Standard Time"));
            }
        }

        private static TimeZoneInfo Get(Timezone tz)
        {
            switch (tz)
            {
                case Timezone.Eastern:
                    return TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                case Timezone.Central:
                    return TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                case Timezone.Mountain:
                    return TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
                case Timezone.Pacific:
                    return TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                case Timezone.Alaska:
                    return TimeZoneInfo.FindSystemTimeZoneById("Alaskan Standard Time");
                case Timezone.Hawaii:
                    return TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");

                default:
                    return TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            }
        }
    }
}
