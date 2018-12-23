using SmartHome.ValueObjects.Dto;
using SmartHome.ValueObjects.Dto.Put;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Hue.BusinessLogic.Contracts
{
    public interface IApiCaller
    {
        Task<IDictionary<int, HueDeviceDto>> GetGeneralLightInfo();

        Task<HueDeviceDto> GetLightInfo(int id);

        Task<bool> ChangeLightState(HueLightStatePutDto statePutDto);
    }
}
