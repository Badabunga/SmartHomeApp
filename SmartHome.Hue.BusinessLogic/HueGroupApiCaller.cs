using AutoMapper;
using Flurl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartHome.Hue.BusinessLogic.Contracts;
using SmartHome.Hue.BusinessLogic.Extensions;
using SmartHome.Hue.BusinessLogic.Handler;
using SmartHome.Hue.BusinessLogic.Helper;
using SmartHome.ValueObjects.Dto;
using SmartHome.ValueObjects.Dto.Group;
using SmartHome.ValueObjects.Dto.Put;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace SmartHome.Hue.BusinessLogic
{
    public class HueGroupApiCaller : IGroupApi
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public HueGroupApiCaller(IConfiguration configuration, ILogger<HueGroupApiCaller> logger, IMapper mapper)
        {
            this._config = configuration;
            this._logger = logger;
            this._mapper = mapper;
            this._responseHandler = new ApiResponseHandler(this._logger);
        }


        public Task<bool> SwitchGroupState(HueSwitchPutDto switchPutDto)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var currentGroup = await this.GetInfo(switchPutDto.Id) ??
                    throw new ArgumentException($"Unter der Id {switchPutDto.Id} konnte keine Gruppe gefunden werden");

                    var content = new GroupStateHandler(this._logger, this._mapper).GetSwtichContent(currentGroup,switchPutDto);

                    if (content.IsNecessary.HasValue && content.IsNecessary.Value)
                    {
                        var response = await this._config["BridgeIP"]
                       .AppendPathSegments("api", this._config["DefaultApiUser"], "groups", switchPutDto.Id, "action")
                       .ToUri()
                       .PostAsJsonAsync(content.content);

                        return this._responseHandler.ResponseContainsErrors(response);
                    }

                    else
                    {
                        if (content.IsNecessary.HasValue) // Status ist schon eingeschalten
                        {
                            this._logger?.LogInformation("Gruppe hat einen ungültigen Status und kann nicht geändert werden");

                            return true;
                        }

                        else
                        {
                            this._logger?.LogCritical("Serializierung hat nicht funktioniert bitte, Log ansehen");

                            return false;
                        }
                    }
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Change State Error");
                    return false;
                }
            });
        }

        public Task<bool> ChangeGroupState(HueGroupStatePutDto hueGroupState)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var currentGroup = await this.GetInfo(hueGroupState.Id) ??
                    throw new ArgumentException($"Unter der Id {hueGroupState.Id} konnte keine Gruppe gefunden werden");

                    var content = new GroupStateHandler(this._logger, this._mapper).GetPostContent(currentGroup,hueGroupState);

                    if (content.isNecessary.HasValue && content.isNecessary.Value)
                    {
                        var response = await this._config["BridgeIP"]
                       .AppendPathSegments("api", this._config["DefaultApiUser"], "groups", hueGroupState.Id, "action")
                       .ToUri().PostAsJsonAsync(content.content);

                        return this._responseHandler.ResponseContainsErrors(response);
                    }

                    else
                    {
                        if (content.isNecessary.HasValue) // Status ist schon eingeschalten
                        {
                            this._logger?.LogInformation("Gruppe hat einen ungültigen Status und kann nicht geändert werden");

                            return true;
                        }

                        else
                        {
                            this._logger?.LogCritical("Serializierung hat nicht funktioniert bitte, Log ansehen");

                            return false;
                        }
                    }
                
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Change State Error");
                    return false;
                }
            });
        }

        public Task<IDictionary<int, HueGroupDto>> GetGeneralInfo()
        {
            return Task.Run(async () =>
            {
                try
                {
                    return await this._config["BridgeIP"]
                   .AppendPathSegments("api", this._config["DefaultApiUser"], "groups")
                   .ToUri()
                   .ReadAsJsonAsync<IDictionary<int, HueGroupDto>>(); ;
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Get Error");
                    return new Dictionary<int, HueGroupDto>();
                }
            });
        }

        public Task<HueGroupDto> GetInfo(int id)
        {
            return Task.Run(async () =>
            {
                try
                {
                    return await this._config["BridgeIP"]
                   .AppendPathSegments("api", this._config["DefaultApiUser"], "groups", id)
                   .ToUri()
                   .ReadAsJsonAsync<HueGroupDto>();
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Get Error");
                    return null;
                }
            });
        }
    }
}
