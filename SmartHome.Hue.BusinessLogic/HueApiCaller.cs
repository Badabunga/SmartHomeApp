using Microsoft.Extensions.Configuration;
using SmartHome.ValueObjects.Dto;
using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using SmartHome.ValueObjects.Dto.Put;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using SmartHome.Hue.BusinessLogic.Extensions;
using Microsoft.Extensions.Logging;
using static SmartHome.Hue.BusinessLogic.Helper.HueApiResponseValidator;
using SmartHome.Hue.BusinessLogic.Contracts;

namespace SmartHome.Hue.BusinessLogic
{
    public class HueApiCaller : IApiCaller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public HueApiCaller(IConfiguration configuration, ILogger<HueApiCaller> logger)
        {
            this._configuration = configuration;
            this._logger = logger;
        }

        public async Task<IDictionary<int, HueDeviceDto>> GetGeneralLightInfo()
        {

            return await Task.Run<IDictionary<int, HueDeviceDto>>(async () =>
            {
                try
                {
                    using (var handler = new HttpClientHandler())
                    using (var client = new HttpClient(handler))
                    {
                        handler.ServerCertificateCustomValidationCallback = this.CheckSslCertificate;

                        var url = this._configuration["BridgeIP"]
                       .AppendPathSegments("api", this._configuration["DefaultApiUser"], "lights")
                       .ToUri();

                        var response = await client.GetAsync(url).ReceiveString();


                        return JsonConvert.DeserializeObject
                        <IDictionary<int, HueDeviceDto>>(response);
                    }
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Get Error");
                    return new Dictionary<int, HueDeviceDto>();
                }
            });
        }


        public Task<HueDeviceDto> GetLightInfo(int id)
        {
            return Task.Run<HueDeviceDto>(async () =>
            {
                try
                {
                    using (var handler = new HttpClientHandler())
                    using (var client = new HttpClient(handler))
                    {
                        handler.ServerCertificateCustomValidationCallback = this.CheckSslCertificate;

                        var url = this._configuration["BridgeIP"]
                       .AppendPathSegments("api", this._configuration["DefaultApiUser"], "lights",id)
                       .ToUri();

                        var response = await client.GetAsync(url).ReceiveString();


                        return JsonConvert.DeserializeObject
                        <HueDeviceDto>(response);
                    }
                }

                catch (Exception ex)
                {
                    this._logger?.LogError(ex, "Während Get Error");
                    return null;
                }
            });
        }

        public Task<bool> ChangeLightState(int id,HueLightStatePutDto statePutDto)
        {
            bool result = false;
            return Task.Run<bool>(async () =>
            {
                try
                {
                    using (var handler = new HttpClientHandler())
                    using (var client = new HttpClient(handler))
                    {
                        handler.ServerCertificateCustomValidationCallback = this.CheckSslCertificate;

                        var url = this._configuration["BridgeIP"]
                       .AppendPathSegments("api", this._configuration["DefaultApiUser"], "lights",id,"state")
                       .ToUri();

                        var getCurrentState = await this.GetLightInfo(id);


                        if (getCurrentState.State.On != statePutDto.On)
                        {
                            var response = await client.PostAsJsonAsync(url, statePutDto);


                            if (!result && TryParseErrorResponseMessage(response, out var errorResponseDto))
                            {
                                errorResponseDto.ForEach(x => this._logger?.LogError("Licht Status konnte nicht geändert werden: " +
                                    $"Type: {x.Error.Type}, {Environment.NewLine} Adress: {x.Error.Address}, " +
                                    $"{Environment.NewLine} Description {x.Error.Description}", x.Error));


                                result = false;
                            }

                            else
                            {
                                result = true;
                            }
                        }

                        else
                        {
                            this._logger.LogInformation("Lampe hat schon den Status der geändert werden sollte");

                            result = true;
                        }

                        return result;
                    }
                }

                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Generlle Exception während ChangeLightState");
                    return false;
                }
            });
        }

        

        private bool CheckSslCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                      System.Security.Cryptography.X509Certificates.X509Chain chain,
                      System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            var startTime = DateTime.Parse(certificate.GetEffectiveDateString());
            var endTime = DateTime.Parse(certificate.GetExpirationDateString());
            if (startTime <= DateTime.Now && endTime >= DateTime.Now && certificate.GetIssuerName().Contains("Philips Hue"))
            {
                return true;

            }

            else
            {
                return false;
            }
        }

       
    }
}
