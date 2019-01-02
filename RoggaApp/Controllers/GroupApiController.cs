using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartHome.Hue.BusinessLogic.Contracts;
using SmartHome.ValueObjects.Dto.Put;

namespace RoggaApp.Controllers
{
    [Route("smarthome/[controller]")]
    [ApiController]
    public class GroupApiController : Controller
    {
        private readonly IConfiguration _config;

        private readonly ILogger _logger;

        private readonly IGroupApi _apiHandler;

        public GroupApiController(IConfiguration configuration, ILogger<GroupApiController> logger, IGroupApi groupApi)
        {
            this._config = configuration;
            this._logger = logger;
            this._apiHandler = groupApi;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Index()
        {
            var lightDevices = this._apiHandler.GetGeneralInfo().Result;

            if (lightDevices.Any())
            {
                return this.Ok(lightDevices);
            }

            else
            {
                this._logger?.LogInformation("Keine Gruppe  gefunden !!");
                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Index(int id)
        {
            var lightDevice = this._apiHandler.GetInfo(id).Result;

            if (lightDevice != null)
            {
                return this.Ok(lightDevice);
            }

            else
            {
                this._logger?.LogInformation($"Keine Gruppe mit der ID {id} gefunden !!");
                return this.NotFound();
            }
        }


        [HttpPut]
        [Route("ChangeState")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> ChangeState([FromBody] HueGroupStatePutDto statePutDto)
        {
            if (statePutDto != null && await this._apiHandler.ChangeGroupState(statePutDto))
            {
                return this.Ok();
            }

            else
            {
                return this.BadRequest("Lampen Status konnte nicht geändert werden, bitte Logs ansehen");
            }
        }



        [HttpPut]
        [Route("SwitchState")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SwitchState([FromBody] HueSwitchPutDto statePutDto)
        {
            if (statePutDto != null && await this._apiHandler.SwitchGroupState(statePutDto))
            {
                return this.Ok();
            }

            else
            {
                return this.BadRequest("Lampen Status konnte nicht geändert werden, bitte Logs ansehen");
            }
        }
    }
}