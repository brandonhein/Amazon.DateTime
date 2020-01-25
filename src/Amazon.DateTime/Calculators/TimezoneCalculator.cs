using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Amazon.DateTime.Calculators
{
    /// <summary>
    /// Timezone Calculator
    /// </summary>
    public static class TimezoneCalculator
    {
        private static ConcurrentDictionary<Timezone, TimeZoneInfo> _selfGenTimezones;
        /// <summary>
        /// Get <see cref="TimeZoneInfo"/> by <see cref="Timezone"/> code
        /// </summary>
        public static TimeZoneInfo GetTimezoneByCode(this TimeZoneInfo tz, Timezone timezone)
        {
            if (timezone == default(Timezone))
            {
                return null;
            }

            if (_selfGenTimezones == null)
            {
                GenerateSelfTimezones();
            }
            return _selfGenTimezones.FirstOrDefault(x => x.Key == timezone).Value;
        }

        private static void GenerateSelfTimezones()
        {
            if (_selfGenTimezones == null)
            {
                _selfGenTimezones = new ConcurrentDictionary<Timezone, TimeZoneInfo>();

                SaveAdd(Timezone.Eastern, TimeZoneInfo.CreateCustomTimeZone("Amazon.DateTime.Eastern", TimeSpan.Parse("-05:00"), "Eastern Standard Time", "Eastern Standard Time"));
                SaveAdd(Timezone.Central, TimeZoneInfo.CreateCustomTimeZone("Amazon.DateTime.Central", TimeSpan.Parse("-06:00"), "Central Standard Time", "Central Standard Time"));
                SaveAdd(Timezone.Mountain, TimeZoneInfo.CreateCustomTimeZone("Amazon.DateTime.Mountain", TimeSpan.Parse("-07:00"), "Mountain Standard Time", "Mountain Standard Time"));
                SaveAdd(Timezone.Pacific, TimeZoneInfo.CreateCustomTimeZone("Amazon.DateTime.Pacific", TimeSpan.Parse("-08:00"), "Pacific Standard Time", "Pacific Standard Time"));
                SaveAdd(Timezone.Alaska, TimeZoneInfo.CreateCustomTimeZone("Amazon.DateTime.Alaska", TimeSpan.Parse("-09:00"), "Alaskan Standard Time", "Alaskan Standard Time"));
                SaveAdd(Timezone.Hawaii, TimeZoneInfo.CreateCustomTimeZone("Amazon.DateTime.Hawaii", TimeSpan.Parse("-10:00"), "Hawaiian Standard Time", "Hawaiian Standard Time"));
            }
        }

        private static void SaveAdd(Timezone tz, TimeZoneInfo info)
        {
            try
            {
                var result = _selfGenTimezones.TryAdd(tz, info);
            }
            catch { }
        }
    }
}
