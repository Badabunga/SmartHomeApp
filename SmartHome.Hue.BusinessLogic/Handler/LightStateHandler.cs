using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartHome.ValueObjects.Dto;
using SmartHome.ValueObjects.Dto.Put;
using SmartHome.ValueObjects.Enums;
using SmartHome.ValueObjects.Dto.Put.LightState;
using System;
using System.Collections.Generic;
using System.Text;
using static SmartHome.ValueObjects.Helper.ConstantConverter;
using SmartHome.Hue.BusinessLogic.Extensions;
using SmartHome.ValueObjects.Dto.Put.LightState.WithoutOn;

namespace SmartHome.Hue.BusinessLogic.Handler
{
    public class LightStateHandler
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public LightStateHandler(ILogger logger, IMapper mapper)
        {
            this._mapper = mapper;
            this._logger = logger;
        }


        public (bool? IsNecessary, string content) GetSwitchStateContent(HueDeviceDto currentDevice,
            HueLightStatePutDto state)
        {
            if(state.On != currentDevice.State.On)
            {
                return this.GetContent(currentDevice, state, false);
            }

            else
            {
                if(currentDevice.State.On) // Soll laut Api nicht immer mit On auf True schicken wenn dieser bereits True ist
                {
                    return this.GetContent(currentDevice, state, true);
                }

                else
                {
                    this._logger?.LogDebug($"Aktueller Status von Light {state.Id} " +
                   $"hat bereits den gewünschten Status {state.On}");

                    return (false, string.Empty);
                }      
            }
        }


        private (bool? IsNecessary, string content) GetContent(HueDeviceDto currentDevice, HueLightStatePutDto state, bool withoutOn)
        {
            if (TryParseHueDeviceType(currentDevice, out var deviceType))
            {

                var contentDto = this.MapToType(deviceType, state,withoutOn);

                if (contentDto == null)
                {
                    this._logger?.LogError($"{nameof(LightStateHandler)} hat den DeviceType {currentDevice.Type} nicht implementiert");

                    return (false, string.Empty);
                }

                else
                {
                    try
                    {
                        return (true, LowerCaseSerializer.SerializeObject(contentDto));
                    }

                    catch (Exception ex)
                    {
                        this._logger?.LogError(ex, "Während der Serialisierung trat ein Fehler auf");

                        return (null, string.Empty);
                    }
                }
            }

            else
            {
                this._logger?.LogError($"Light {currentDevice.Name} hat einen ungültigen Type {currentDevice.Type}");
                return (null, string.Empty);
            }
        }


        private object MapToType(EHueDeviceType deviceType, HueLightStatePutDto state, bool withoutOn)
        {
            object contentDto = null;

            switch (deviceType)
            {
                case EHueDeviceType.Extended_Color_Light:
                    contentDto = withoutOn ? (object)this._mapper.Map<ExtendedColorLightWithoutOnPutDto>(state) : this._mapper.Map<ExtendedColorLightStatePutDto>(state);
                    break;

                case EHueDeviceType.Temperature_Light:
                    contentDto = withoutOn ? (object)this._mapper.Map<ColorTemperaturWithoutOnPutDto>(state) :  this._mapper.Map<ColorTemperatureLightPutStateDto>(state);
                    break;

                default:
                    contentDto = null;
                    break;
            }

            return contentDto;
        }
    }
}
