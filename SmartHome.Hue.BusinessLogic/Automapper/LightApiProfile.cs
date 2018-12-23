using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SmartHome.ValueObjects.Dto.Put;
using SmartHome.ValueObjects.Dto.Put.LightState;
using SmartHome.ValueObjects.Dto.Put.LightState.WithoutOn;

namespace SmartHome.Hue.BusinessLogic.Automapper
{
    public class LightApiProfile : AutoMapper.Profile
    {
        public LightApiProfile()
        {
            CreateMap<HueLightStatePutDto, ColorTemperatureLightPutStateDto>();
            CreateMap<HueLightStatePutDto, ColorTemperaturWithoutOnPutDto>();
            CreateMap<ColorTemperatureLightPutStateDto, ColorTemperaturWithoutOnPutDto>().ReverseMap();

            CreateMap<HueLightStatePutDto, ExtendedColorLightStatePutDto>();
            CreateMap<HueLightStatePutDto, ExtendedColorLightWithoutOnPutDto>();
            CreateMap<ExtendedColorLightStatePutDto, ExtendedColorLightWithoutOnPutDto>().ReverseMap();
        }
    }
}
