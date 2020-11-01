namespace Amazon.DateTime.Serialization
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class NewtonsoftDateTimeConverter : IsoDateTimeConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeBase) || objectType == typeof(EasternDateTime) || objectType == typeof(CentralDateTime) ||
                 objectType == typeof(MountainDateTime) || objectType == typeof(PacificDateTime) || objectType == typeof(AlaskaDateTime) ||
                 objectType == typeof(HawaiiDateTime) || objectType == typeof(UniversalDateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dateTime = (DateTime?)base.ReadJson(reader, typeof(DateTime?), existingValue, serializer);
            if (dateTime.HasValue)
            {
                if (objectType == typeof(EasternDateTime))
                {
                    return EasternDateTime.Convert(dateTime.Value);
                }
                else if (objectType == typeof(CentralDateTime))
                {
                    return CentralDateTime.Convert(dateTime.Value);
                }
                else if (objectType == typeof(MountainDateTime))
                {
                    return MountainDateTime.Convert(dateTime.Value);
                }
                else if (objectType == typeof(PacificDateTime))
                {
                    return PacificDateTime.Convert(dateTime.Value);
                }
                else if (objectType == typeof(AlaskaDateTime))
                {
                    return AlaskaDateTime.Convert(dateTime.Value);
                }
                else if (objectType == typeof(HawaiiDateTime))
                {
                    return HawaiiDateTime.Convert(dateTime.Value);
                }
                else if (objectType == typeof(UniversalDateTime))
                {
                    return UniversalDateTime.Convert(dateTime.Value);
                }
            }

            return null;
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
    }
}
