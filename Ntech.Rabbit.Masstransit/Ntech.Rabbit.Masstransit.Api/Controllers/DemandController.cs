using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ntech.Rabbit.Masstransit.Api.Model;
using Ntech.Rabbit.Masstransit.MessageContracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using GreenPipes;

namespace Ntech.Rabbit.Masstransit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {


        // POST: api/Demand
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterDemandModel demand)
        {

            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.RegisterDemandServiceQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<IRegisterDemandCommand>(new
            {
                Subject = demand.Subject,
                Description = demand.Description
            });
            return Ok("Sent...");
        }
    }

}
