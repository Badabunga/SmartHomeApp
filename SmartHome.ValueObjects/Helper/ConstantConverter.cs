using SmartHome.ValueObjects.Dto;
using SmartHome.ValueObjects.Enums;
using System;
using System.Collections.Generic;
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
    }
}
