using Microsoft.Extensions.Configuration;
using SmartHome.ValueObjects.Dto;
using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Net.Http;
using SmartHome.ValueObjects.Dto.Put;
using SmartHome.Hue.BusinessLogic.Extensions;
using Microsoft.Extensions.Logging;
using SmartHome.Hue.BusinessLogic.Contracts;
using SmartHome.Hue.BusinessLogic.Handler;
using AutoMapper;

namespace SmartHome.Hue.BusinessLogic
{
    public class HueLightApiCaller : ILightApi
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public HueLightApiCaller(IConfiguration configuration, ILogger<HueLightApiCaller> logger, IMapper mapper)
        {
            this._configuration = configuration;
            this._logger = logger;
            this._mapper = mapper;
            this._responseHandler = new ApiResponseHandler(this._logger);
        }

        public async Task<IDictionary<int, HueDeviceDto>> GetGeneralInfo()
        {

            return await Task.Run(async () =>
            {
                try
                {
                    return await this._configuration["BridgeIP"]
                   .AppendPathSegments("api", this._configuration["DefaultApiUser"], "lights")
                   .ToUri()
                   .ReadAsJsonAsync<IDictionary<int, HueDeviceDto>>();
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Get Error");
                    return new Dictionary<int, HueDeviceDto>();
                }
            });
        }


        public Task<HueDeviceDto> GetInfo(int id)
        {
            return Task.Run(async () =>
            {
                try
                {
                    return await this._configuration["BridgeIP"]
                   .AppendPathSegments("api", this._configuration["DefaultApiUser"], "lights", id)
                   .ToUri()
                   .ReadAsJsonAsync<HueDeviceDto>();
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Get Error");
                    return null;
                }
            });
        }

        public Task<bool> ChangeLightState(HueLightStatePutDto statePutDto)
        {
            bool result = false;
            return Task.Run<bool>(async () =>
            {
                try
                {
                    var currentState = await this.GetInfo(statePutDto.Id) ?? throw new Exception("Lampe mit der ID {statePutDto.Id} konnte nicht gefunden werden !! Ist diese Registriert ? ");

                    var content = new LightStateHandler(this._logger, this._mapper).GetSwitchStateContent(currentState, statePutDto);

                    if (content.IsNecessary.HasValue && content.IsNecessary.Value)
                    {
                        var response = await this._configuration["BridgeIP"]
                                                 .AppendPathSegments("api", this._configuration["DefaultApiUser"], "lights", statePutDto.Id, "state")
                                                 .ToUri()
                                                 .PostAsJsonAsync(content.content);

                        return this._responseHandler.ResponseContainsErrors(response);
                    }

                    else
                    {
                        if (content.IsNecessary.HasValue)
                        {
                            this._logger?.LogInformation("Lampe hat einen ungültigen Status und kann nicht geändert werden");

                            result = true;
                        }

                        else
                        {
                            this._logger?.LogCritical("Serializierung hat nicht funktioniert bitte, Log ansehen");

                            result = false;
                        }
                    }

                    return result;
                }

                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Generelle Exception während ChangeLightState");
                    return false;
                }
            });
        } 
    }
}
