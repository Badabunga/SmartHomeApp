using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmartHome.Hue.BusinessLogic.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri url, T data)
        {
            var dataString = LowerCaseSerializer.SerializeObject(data);

            var content = new StringContent(dataString);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            return client.PutAsync(url, content);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }
    }
}
