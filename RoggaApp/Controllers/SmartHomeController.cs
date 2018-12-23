using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartHome.ValueObjects.Dto;
using SmartHome.Hue.BusinessLogic;
using SmartHome.ValueObjects.Dto.Put;
using Microsoft.Extensions.Logging;
using SmartHome.Hue.BusinessLogic.Contracts;

namespace RoggaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartHomeController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger _logger;

        private readonly IApiCaller _caller;

        public SmartHomeController(IConfiguration configuration, ILogger<SmartHomeController> logger, IApiCaller apiCaller)
        {
            this._configuration = configuration;
            this._logger = logger;

            this._caller = apiCaller;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IDictionary<int, HueDeviceDto>> Get()
        {

            var lightDevices = this._caller.GetGeneralLightInfo().Result;

            if (lightDevices.Any())
            {
                return this.Ok(lightDevices);
            }

            else
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<HueDeviceDto> Get(int id)
        {
            var lightDevice = this._caller.GetLightInfo(id).Result;

            if(lightDevice != null)
            {
                return this.Ok(lightDevice);
            }

            else
            {
                return this.NotFound();
            }
        }



        [HttpPut]
        [Route("ChangeState/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> ChangeState(int id,[FromBody] HueLightStatePutDto statePutDto)
        {
            if (statePutDto != null && await this._caller.ChangeLightState(id,statePutDto))
            {
                return this.Ok();
            }

            else
            {
                return this.BadRequest("Konnte Lampe nicht finden");
            }
        }
    }
}