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
    public class CallbackController : ControllerBase
    {

        IRequestClient<CheckOrderStatus> _client;

        public CallbackController(IRequestClient<CheckOrderStatus> client)
        {
            _client = client;
        }

        public async Task<ActionResult> Get(string id)
        {
            var response = await _client.GetResponse<OrderStatusResult>(new { OrderId = id });

            return Ok(response.Message);
        }
    }

}
