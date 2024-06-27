using System;
using System.ComponentModel;
using System.Globalization;

namespace Amazon.DateTime.Serialization
{
    public class ComponentModelDateTimeConverter<T> : TypeConverter where T : DateTimeBase
    {
        private readonly Type _type;
        public ComponentModelDateTimeConverter() => _type = typeof(T);

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            var canConvert = sourceType == typeof(DateTimeBase) || sourceType == _type;

            if (canConvert)
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var valueString = value != null ? value.ToString() : null;

            if (!string.IsNullOrEmpty(valueString))
            {
                if (_type == typeof(EasternDateTime) && EasternDateTime.TryParse(valueString, out var easternDateTime))
                    return easternDateTime;

                if (_type == typeof(CentralDateTime) && CentralDateTime.TryParse(valueString, out var centralDateTime))
                    return centralDateTime;

                if (_type == typeof(MountainDateTime) && MountainDateTime.TryParse(valueString, out var mountainDateTime))
                    return mountainDateTime;

                if (_type == typeof(PacificDateTime) && PacificDateTime.TryParse(valueString, out var pacificDateTime))
                    return pacificDateTime;

                if (_type == typeof(AlaskaDateTime) && AlaskaDateTime.TryParse(valueString, out var alaskaDateTime))
                    return alaskaDateTime;

                if (_type == typeof(HawaiiDateTime) && HawaiiDateTime.TryParse(valueString, out var hawaiiDateTime))
                    return hawaiiDateTime;

                if (_type == typeof(UniversalDateTime) && UniversalDateTime.TryParse(valueString, out var universalDateTime))
                    return universalDateTime;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
