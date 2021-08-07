using MassTransit;
using Ntech.Rabbit.Masstransit.MessageContracts;
using System;
using System.Threading.Tasks;

namespace Callback
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
                x.ReceiveEndpoint(host, "MtPubSubExample_TestPublisher", e =>
                    e.Consumer<ResponseConsumer>());
            });
            bus.Start();
            var text = "";
            Console.WriteLine("Publisher");
            Console.Write("Enter a message: ");
            text = Console.ReadLine();

            var message = new SomethingHappenedMessage()
            {
                What = text,
                When = DateTime.Now
            };
            bus.Publish(message);

            bus.Stop();
        }
    }

    class ResponseConsumer : IConsumer<IResponse>
    {
        public Task Consume(ConsumeContext<IResponse> context)
        {
            Console.WriteLine("RESPONSE MESSAGE: " + context.Message.Message);
            return Task.FromResult(0);
        }
    }
}
