using Ntech.Rabbit.Masstransit.MessageContracts;
using GreenPipes;
using MassTransit;
using System;

namespace Ntech.Rabbit.Masstransit.Notification
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.Title = "Notification";
            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(RabbitMqConsts.NotificationServiceQueue, e =>
                {
                    e.Consumer<DemandRegisteredEventConsumer>();
                    e.UseMessageRetry(r => r.Immediate(5));
                });
            });

            bus.StartAsync();
            Console.WriteLine("Listening for Demand registered events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();

        }
    }
}
