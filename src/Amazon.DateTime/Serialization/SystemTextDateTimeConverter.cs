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
            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetInt64(out var unixSeconds))
                {
                    var utcDateTime = FromUnixTime(unixSeconds);
                    if (typeToConvert == typeof(EasternDateTime))
                        return EasternDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(CentralDateTime))
                        return CentralDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(MountainDateTime))
                        return MountainDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(PacificDateTime))
                        return PacificDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(AlaskaDateTime))
                        return AlaskaDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(HawaiiDateTime))
                        return HawaiiDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(UniversalDateTime))
                        return UniversalDateTime.Convert(utcDateTime);
                }

                if (reader.TryGetDecimal(out var unixDecimalSeconds))
                {
                    var utcDateTime = FromUnixTime(Convert.ToInt64(unixDecimalSeconds));
                    if (typeToConvert == typeof(EasternDateTime))
                        return EasternDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(CentralDateTime))
                        return CentralDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(MountainDateTime))
                        return MountainDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(PacificDateTime))
                        return PacificDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(AlaskaDateTime))
                        return AlaskaDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(HawaiiDateTime))
                        return HawaiiDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(UniversalDateTime))
                        return UniversalDateTime.Convert(utcDateTime);
                }
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();

                if (typeToConvert == typeof(EasternDateTime) && EasternDateTime.TryParse(value, out var easternDateTime))
                    return easternDateTime;

                else if (typeToConvert == typeof(CentralDateTime) && CentralDateTime.TryParse(value, out var centralDateTime))
                    return centralDateTime;

                else if (typeToConvert == typeof(MountainDateTime) && MountainDateTime.TryParse(value, out var mountainDateTime))
                    return mountainDateTime;

                else if (typeToConvert == typeof(PacificDateTime) && PacificDateTime.TryParse(value, out var pacificDateTime))
                    return pacificDateTime;

                else if (typeToConvert == typeof(AlaskaDateTime) && AlaskaDateTime.TryParse(value, out var alaskaDateTime))
                    return alaskaDateTime;

                else if (typeToConvert == typeof(HawaiiDateTime) && HawaiiDateTime.TryParse(value, out var hawaiiDateTime))
                    return hawaiiDateTime;

                else if (typeToConvert == typeof(UniversalDateTime) && UniversalDateTime.TryParse(value, out var utcDateTime))
                    return utcDateTime;


                if (long.TryParse(value, out var unixSeconds))
                {
                    var utcDateTime = FromUnixTime(unixSeconds);
                    if (typeToConvert == typeof(EasternDateTime))
                        return EasternDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(CentralDateTime))
                        return CentralDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(MountainDateTime))
                        return MountainDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(PacificDateTime))
                        return PacificDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(AlaskaDateTime))
                        return AlaskaDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(HawaiiDateTime))
                        return HawaiiDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(UniversalDateTime))
                        return UniversalDateTime.Convert(utcDateTime);
                }

                if (decimal.TryParse(value, out var unixDecmialSeconds))
                {
                    var utcDateTime = FromUnixTime(Convert.ToInt64(unixDecmialSeconds));
                    if (typeToConvert == typeof(EasternDateTime))
                        return EasternDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(CentralDateTime))
                        return CentralDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(MountainDateTime))
                        return MountainDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(PacificDateTime))
                        return PacificDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(AlaskaDateTime))
                        return AlaskaDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(HawaiiDateTime))
                        return HawaiiDateTime.Convert(utcDateTime);

                    if (typeToConvert == typeof(UniversalDateTime))
                        return UniversalDateTime.Convert(utcDateTime);
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeBase value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }

        private DateTime FromUnixTime(long unixTime)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return result.AddSeconds(unixTime);
        }
    }
}
