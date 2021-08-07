﻿using Ntech.Rabbit.Masstransit.MessageContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ntech.Rabbit.Masstransit.Thirdparty.Service
{
    public class DemandRegisteredEventConsumer : IConsumer<IRegisteredDemandEvent>
    {
        public async Task Consume(ConsumeContext<IRegisteredDemandEvent> context)
        {
            await Console.Out.WriteLineAsync($"Thirdpary integratin done: Demand id {context.Message.DemandId}, Time:{DateTime.Now}");
        }
    }
}

