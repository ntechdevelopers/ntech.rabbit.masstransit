using Ntech.Rabbit.Masstransit.MessageContracts;
using GreenPipes;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ntech.Rabbit.Masstransit.Registration
{
    public class RegisterDemandCommandConsumer : IConsumer<IRegisterDemandCommand>
    {
        public async Task Consume(ConsumeContext<IRegisterDemandCommand> context)
        {
            var message = context.Message;
            var guid = Guid.NewGuid();
            Console.WriteLine($"Demand successfully  registered. Subject:{message.Subject}, Description:{message.Description}, Id:{guid}, Time:{DateTime.Now}");
            await context.Publish<IRegisteredDemandEvent>(new
            {
                DemandId = guid
            });
        }
    }
}
