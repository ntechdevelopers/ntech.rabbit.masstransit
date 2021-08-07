using Ntech.Rabbit.Masstransit.MessageContracts;
using GreenPipes;
using MassTransit;
using System;

namespace Ntech.Rabbit.Masstransit.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Registration";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(
                    RabbitMqConsts.RegisterDemandServiceQueue, e =>
                    {
                        e.Consumer<RegisterDemandCommandConsumer>();
                        e.UseCircuitBreaker(cb =>
                        {
                            cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                            cb.TripThreshold = 15;
                            cb.ActiveThreshold = 10;
                            cb.ResetInterval = TimeSpan.FromMinutes(5);
                        });
                     
                    });
              
            });

            bus.StartAsync();

            Console.WriteLine("Listening for Register Demand commands.. " +
                              "Press enter to exit");
            Console.ReadLine();

            bus.StopAsync();
        }
    }
}
