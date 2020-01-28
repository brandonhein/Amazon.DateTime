namespace Amazon.DateTime
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;

    public class JsonDateTimeConverter : IsoDateTimeConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeBase);
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
