using Newtonsoft.Json;
using SmartHome.ValueObjects.Dto.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SmartHome.Hue.BusinessLogic.Helper
{
    public static class HueApiResponseValidator
    {
        public static bool TryParseErrorResponseMessage(HttpResponseMessage responseMessage, 
            out List<ApiErrorResponseContainer> errorDto)
        {
            var message = responseMessage.Content.ReadAsStringAsync().Result;

            if(message.Contains("error"))
            {
                errorDto = JsonConvert.DeserializeObject<List<ApiErrorResponseContainer>>(message);

                errorDto.RemoveAll(x => x.Error == null);

                return true;
            }

            else
            {
                errorDto = null;

                return false;
            }
        }
    }
}
