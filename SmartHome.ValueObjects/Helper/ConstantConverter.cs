using SmartHome.ValueObjects.Dto;
using SmartHome.ValueObjects.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartHome.ValueObjects.Helper
{
    public static class ConstantConverter
    {
        public const string LightType_ExtendedColorLight = "Extended color light";

        public const string LightType_ColorTemperatureLight = "Color temperature light";

        public static bool TryParseHueDeviceType(HueDeviceDto hueDevice, out EHueDeviceType deviceType)
        {
            if(!string.IsNullOrEmpty(hueDevice.Type))
            {
                bool result = false;
                switch(hueDevice.Type)
                {
                    case LightType_ColorTemperatureLight:
                        deviceType = EHueDeviceType.Temperature_Light;
                        result = true;
                        break;

                    case LightType_ExtendedColorLight:
                        deviceType = EHueDeviceType.Extended_Color_Light;
                        result = true;
                        break;

                    default:
                        deviceType = EHueDeviceType.Unkown;
                        result = false;
                        break;
                }


                return result;
            }

            else
            {
                deviceType = EHueDeviceType.Unkown;
                return false;
            }

        }


        public static T GetEnumThroughDisplayName<T>(string displayName) where T: Enum
        {

            foreach (var field in typeof(T).GetFields())
            {

                var name = GetDisplayNameThroughEnum((T)field.GetValue(null));

                if(!string.IsNullOrEmpty(name))
                {
                    if(string.Equals(name,displayName))
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException($"Could not find an Enum with the DisplayName {displayName}");
        }

        public static string GetDisplayNameThroughEnum<T>(T value) where T: Enum
        {
            var attr = value.GetType().GetField(value.ToString())
                  .GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (attr == null)
            {
                throw new NotImplementedException($"Enum {value} has no implemented Display Attribute");
            }

            else
            {
                return attr.FirstOrDefault()?.Name;
            }
        }
    }
}
