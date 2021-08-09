using MassTransit;
using Ntech.Rabbit.Masstransit.MessageContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ntech.Rabbit.Masstransit.Registration
{
    public class CheckOrderStatusConsumer : IConsumer<CheckOrderStatus>
    {

        public async Task Consume(ConsumeContext<CheckOrderStatus> context)
        {
            var order = context.Message.OrderId;

            await context.RespondAsync<OrderStatusResult>(new
            {
                OrderId = order,
                Timestamp = DateTime.Now,
                StatusCode = "Done",
                StatusText = "CheckOrderStatusConsumer"
            });
        }
    }
}
