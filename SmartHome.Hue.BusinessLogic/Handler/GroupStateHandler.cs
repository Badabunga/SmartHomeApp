using AutoMapper;
using Microsoft.Extensions.Logging;
using SmartHome.Hue.BusinessLogic.Extensions;
using SmartHome.ValueObjects.Dto.Group;
using SmartHome.ValueObjects.Dto.Put;
using SmartHome.ValueObjects.Dto.Put.GroupState;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Hue.BusinessLogic.Handler
{
    public class GroupStateHandler
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GroupStateHandler(ILogger logger, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
        }



        public (bool? isNecessary, string content) GetPostContent(HueGroupDto currentGroup, HueGroupStatePutDto wantedState)
        {
            if (wantedState.On != currentGroup.Action.On)
            {
                return this.GetContent(currentGroup, wantedState, false);
            }

            else
            {
                if (currentGroup.Action.On) // Soll laut Api nicht immer mit On auf True schicken wenn dieser bereits True ist
                {
                    return this.GetContent(currentGroup, wantedState, true);
                }

                else
                {
                    this._logger?.LogDebug($"Aktueller Status von Gruppe {currentGroup.Name} " +
                   $"hat bereits den gewünschten Status {currentGroup.Action.On}");

                    return (false, string.Empty);
                }
            }
        }

        public (bool? IsNecessary, string content) GetSwtichContent(HueGroupDto currentGroup, HueSwitchPutDto switchDto)
        {
            var newPutDto = new HueGroupStatePutDto
            {
                Id = switchDto.Id,
                On = !currentGroup.Action.On
            };

            return this.GetContent(currentGroup, newPutDto, false);
        }


        private (bool? IsNecessary, string content) GetContent(HueGroupDto currentGroup, HueGroupStatePutDto state, bool withoutOn)
        {
            object content = null;

            if(withoutOn)
            {
                content = this._mapper.Map<GroupStateWithoutOnPut>(state);            
            }

            else
            {
                content = this._mapper.Map<GroupStateWithOnPut>(state);
            }

            if (content == null)
            {
                this._logger?.LogError($"{nameof(GroupStateHandler)}hat keinen gültigen Status Wert");

                return (false, string.Empty);
            }

            try
            {
                return (true, LowerCaseSerializer.SerializeObjectWithoutNullProperties(content));
            }

            catch(Exception ex)
            {
                this._logger?.LogError(ex, "Während der Serialisierung trat ein Fehler auf");

                return (null, string.Empty);
            }
        }
    }
}
