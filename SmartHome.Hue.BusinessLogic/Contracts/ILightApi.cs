using SmartHome.ValueObjects.Dto.Put;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Hue.BusinessLogic.Contracts
{
    public interface ILightApi : IApiCaller
    {
        Task<bool> ChangeLightState(HueLightStatePutDto statePutDto);
    }
}
