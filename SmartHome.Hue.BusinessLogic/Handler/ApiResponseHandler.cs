using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartHome.ValueObjects.Dto.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SmartHome.Hue.BusinessLogic.Handler
{
    public class ApiResponseHandler
    {
        private readonly ILogger _logger;
        public ApiResponseHandler(ILogger logger)
        {
            this._logger = logger;
        }


        public bool ResponseContainsErrors(HttpResponseMessage httpResponse)
        {
            if (this.TryParseErrorResponseMessage(httpResponse, out var errorResponseDto))
            {
                errorResponseDto.ForEach(x => this._logger?.LogError("Device Status konnte nicht geändert werden: " +
                    $"Type: {x.Error.Type}, {Environment.NewLine} Adress: {x.Error.Address}, " +
                    $"{Environment.NewLine} Description {x.Error.Description}", x.Error));


                return false;
            }

            else
            {
                return true;
            }
        }



        private bool TryParseErrorResponseMessage(HttpResponseMessage responseMessage,
            out List<ApiErrorResponseContainer> errorDto)
        {
            var message = responseMessage.Content.ReadAsStringAsync().Result;

            if (message.Contains("error"))
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
