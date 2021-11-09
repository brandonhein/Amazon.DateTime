namespace Amazon.DateTime.Serialization
{
    using Newtonsoft.Json;
    using System;

    public class NewtonsoftDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeBase) || objectType == typeof(EasternDateTime) || objectType == typeof(CentralDateTime) ||
                 objectType == typeof(MountainDateTime) || objectType == typeof(PacificDateTime) || objectType == typeof(AlaskaDateTime) ||
                 objectType == typeof(HawaiiDateTime) || objectType == typeof(UniversalDateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            if (value == null)
                return default(DateTimeBase);

            if (reader.ValueType == typeof(DateTime) || reader.ValueType == typeof(DateTimeOffset))
            {
                if (objectType == typeof(EasternDateTime))
                    return EasternDateTime.Convert((DateTime)value);
                if (objectType == typeof(CentralDateTime))
                    return CentralDateTime.Convert((DateTime)value);
                if (objectType == typeof(MountainDateTime))
                    return MountainDateTime.Convert((DateTime)value);
                if (objectType == typeof(PacificDateTime))
                    return PacificDateTime.Convert((DateTime)value);
                if (objectType == typeof(AlaskaDateTime))
                    return AlaskaDateTime.Convert((DateTime)value);
                if (objectType == typeof(HawaiiDateTime))
                    return HawaiiDateTime.Convert((DateTime)value);
                if (objectType == typeof(UniversalDateTime))
                    return UniversalDateTime.Convert((DateTime)value);
            }

            var stringValue = value.ToString();
            if (long.TryParse(stringValue, out var unixSeconds))
            {
                var utcDateTime = FromUnixTime(unixSeconds);
                if (objectType == typeof(EasternDateTime))
                    return EasternDateTime.Convert(utcDateTime);
                if (objectType == typeof(CentralDateTime))
                    return CentralDateTime.Convert(utcDateTime);
                if (objectType == typeof(MountainDateTime))
                    return MountainDateTime.Convert(utcDateTime);
                if (objectType == typeof(PacificDateTime))
                    return PacificDateTime.Convert(utcDateTime);
                if (objectType == typeof(AlaskaDateTime))
                    return AlaskaDateTime.Convert(utcDateTime);
                if (objectType == typeof(HawaiiDateTime))
                    return HawaiiDateTime.Convert(utcDateTime);
                if (objectType == typeof(UniversalDateTime))
                    return UniversalDateTime.Convert(utcDateTime);
            }

            if (decimal.TryParse(stringValue, out var unixDecmialSeconds))
            {
                var utcDateTime = FromUnixTime(Convert.ToInt64(unixDecmialSeconds));
                if (objectType == typeof(EasternDateTime))
                    return EasternDateTime.Convert(utcDateTime);
                if (objectType == typeof(CentralDateTime))
                    return CentralDateTime.Convert(utcDateTime);
                if (objectType == typeof(MountainDateTime))
                    return MountainDateTime.Convert(utcDateTime);
                if (objectType == typeof(PacificDateTime))
                    return PacificDateTime.Convert(utcDateTime);
                if (objectType == typeof(AlaskaDateTime))
                    return AlaskaDateTime.Convert(utcDateTime);
                if (objectType == typeof(HawaiiDateTime))
                    return HawaiiDateTime.Convert(utcDateTime);
                if (objectType == typeof(UniversalDateTime))
                    return UniversalDateTime.Convert(utcDateTime);
            }

            if (DateTime.TryParse(stringValue, out var dateTime))
            {
                if (objectType == typeof(EasternDateTime))
                    return EasternDateTime.Convert(dateTime);
                if (objectType == typeof(CentralDateTime))
                    return CentralDateTime.Convert(dateTime);
                if (objectType == typeof(MountainDateTime))
                    return MountainDateTime.Convert(dateTime);
                if (objectType == typeof(PacificDateTime))
                    return PacificDateTime.Convert(dateTime);
                if (objectType == typeof(AlaskaDateTime))
                    return AlaskaDateTime.Convert(dateTime);
                if (objectType == typeof(HawaiiDateTime))
                    return HawaiiDateTime.Convert(dateTime);
                if (objectType == typeof(UniversalDateTime))
                    return UniversalDateTime.Convert(dateTime);
            }

            return default(DateTimeBase);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string text = null;
            if (value is DateTimeBase dateTime)
            {
                text = dateTime.Value;
            }

            writer.WriteValue(text);
        }

        private DateTime FromUnixTime(long unixTime)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return result.AddSeconds(unixTime);
        }
    }
}
