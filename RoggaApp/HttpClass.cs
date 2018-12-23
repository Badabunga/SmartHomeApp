using Microsoft.Extensions.Configuration;
using SmartHome.ValueObjects.Dto;
using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace RoggaApp
{
    public class HttpClass
    {
        private readonly IConfiguration _configuration;

        public HttpClass(IConfiguration configuration)
        {
            this._configuration = configuration;



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

                        var response = await client.GetAsync(url);
                    }

                    return new Dictionary<int, HueDeviceDto>();

                }

                catch (Exception ex)
                {

                    return new Dictionary<int, HueDeviceDto>();
                }
            });
        }


        private bool CheckSslCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                      System.Security.Cryptography.X509Certificates.X509Chain chain,
                      System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            var startTime = DateTime.Parse(certificate.GetEffectiveDateString());
            var endTime = DateTime.Parse(certificate.GetExpirationDateString());
            if(startTime <= DateTime.Now && endTime >= DateTime.Now && certificate.GetIssuerName().Contains("Philips Hue"))
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
