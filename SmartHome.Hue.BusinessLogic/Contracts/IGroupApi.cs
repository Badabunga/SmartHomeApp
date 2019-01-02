using SmartHome.ValueObjects.Dto.Group;
using SmartHome.ValueObjects.Dto.Put;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Hue.BusinessLogic.Contracts
{
    public interface IGroupApi
    {
        Task<IDictionary<int, HueGroupDto>> GetGeneralInfo();

        Task<HueGroupDto> GetInfo(int id);

        Task<bool> ChangeGroupState(HueGroupStatePutDto putState);

        Task<bool> SwitchGroupState(HueSwitchPutDto switchPutDto);
    }
}
