using SmartHome.ValueObjects.Dto.Put;
using SmartHome.ValueObjects.Dto.Put.GroupState;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace SmartHome.Hue.BusinessLogic.Automapper
{
    public class GroupApiProfile : Profile
    {
        public GroupApiProfile()
        {
            CreateMap<HueGroupStatePutDto, GroupStateWithoutOnPut>().ReverseMap();
            CreateMap<HueGroupStatePutDto, GroupStateWithOnPut>().ReverseMap();
        }
    }
}
