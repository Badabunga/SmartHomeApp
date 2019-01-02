using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static SmartHome.Hue.BusinessLogic.Helper.CertificateHelper;

namespace SmartHome.Hue.BusinessLogic.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this Uri url, T data) where T : class
        {
            var dataString = LowerCaseSerializer.SerializeObject(data);

            return PostAsJsonAsync(url, dataString);
        }


        public static Task<HttpResponseMessage> PostAsJsonAsync(this Uri url, string data)
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                handler.ServerCertificateCustomValidationCallback = CheckSslCertificate;
                var content = new StringContent(data);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                return client.PutAsync(url, content);
            }
        }

        public static async Task<T> ReadAsJsonAsync<T>(this Uri url)
        {
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                handler.ServerCertificateCustomValidationCallback = CheckSslCertificate;

                var dataAsString = await client.GetStringAsync(url.ToString());
                return JsonConvert.DeserializeObject<T>(dataAsString);
            }
        }
    }
}
