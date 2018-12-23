using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmartHome.Hue.BusinessLogic.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri url, T data) where T : class
        {
            var dataString = LowerCaseSerializer.SerializeObject(data);

            return PostAsJsonAsync(client, url, dataString);
        }


        public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, Uri url, string data)
        {
            var content = new StringContent(data);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            return client.PutAsync(url, content);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpClient client, Uri url)
        {
            var dataAsString = await client.GetStringAsync(url.ToString());
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }
    }
}
