using MassTransit;
using Ntech.Rabbit.Masstransit.MessageContracts;
using System;
using System.Threading.Tasks;

namespace Ntech.Rabbit.Masstransit.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
                x.ReceiveEndpoint(host, "MtPubSubExample_TestSubscriber", e =>
                    e.Consumer<SomethingHappenedConsumer>());
            });
            Console.WriteLine("Subscriber");
            bus.Start();
            Console.ReadKey();
            bus.Stop();
        }

        class SomethingHappenedConsumer : IConsumer<ISomethingHappened>
        {
            private IBusControl bus = Bus.Factory.CreateUsingRabbitMq(x =>
                x.Host(new Uri("rabbitmq://localhost/"), h => { }));

            public Task Consume(ConsumeContext<ISomethingHappened> context)
            {
                var now = DateTime.Now;
                Console.Write("TXT: " + context.Message.What);
                Console.Write("  SENT: " + context.Message.When);
                Console.Write("  PROCESSED: " + now);
                Console.WriteLine(" (" + System.Threading.Thread.CurrentThread.ManagedThreadId + ")");

                var response = new ResponseMessage()
                {
                    Message = "The request was processed at " + now
                };

                bus.Publish(response);
                return Task.FromResult(0);
            }
        }
    }
}
