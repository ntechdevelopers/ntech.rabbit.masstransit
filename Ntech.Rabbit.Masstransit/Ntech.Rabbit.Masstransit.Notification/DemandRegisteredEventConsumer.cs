using Ntech.Rabbit.Masstransit.MessageContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ntech.Rabbit.Masstransit.Notification
{
    public class DemandRegisteredEventConsumer : IConsumer<IRegisteredDemandEvent>
    {
        public async Task Consume(ConsumeContext<IRegisteredDemandEvent> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: Demand id {context.Message.DemandId}, Time:{DateTime.Now}");
        }
    }
}
