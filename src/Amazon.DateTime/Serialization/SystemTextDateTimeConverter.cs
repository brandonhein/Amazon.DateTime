namespace Amazon.DateTime.Serialization
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class SystemTextDateTimeConverter : JsonConverter<DateTimeBase>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeBase) || objectType == typeof(EasternDateTime) || objectType == typeof(CentralDateTime) ||
                objectType == typeof(MountainDateTime) || objectType == typeof(PacificDateTime) || objectType == typeof(AlaskaDateTime) ||
                objectType == typeof(HawaiiDateTime) || objectType == typeof(UniversalDateTime);
        }

        public override DateTimeBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParse(reader.GetString(), out var result))
            {
                if (typeToConvert == typeof(EasternDateTime))
                {
                    return EasternDateTime.Convert(result);
                }
                else if (typeToConvert == typeof(CentralDateTime))
                {
                    return CentralDateTime.Convert(result);
                }
                else if (typeToConvert == typeof(MountainDateTime))
                {
                    return MountainDateTime.Convert(result);
                }
                else if (typeToConvert == typeof(PacificDateTime))
                {
                    return PacificDateTime.Convert(result);
                }
                else if (typeToConvert == typeof(AlaskaDateTime))
                {
                    return AlaskaDateTime.Convert(result);
                }
                else if (typeToConvert == typeof(HawaiiDateTime))
                {
                    return HawaiiDateTime.Convert(result);
                }
                else if (typeToConvert == typeof(UniversalDateTime))
                {
                    return UniversalDateTime.Convert(result);
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeBase value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
