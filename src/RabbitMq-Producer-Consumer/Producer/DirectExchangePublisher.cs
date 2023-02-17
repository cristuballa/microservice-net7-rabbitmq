using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class DirectExchangePublisher 
 {
    private static int count;

    public static void Publish(IModel channel)
    {
            channel.ExchangeDeclare("demo-direct-exchange",ExchangeType.Direct);

        while(true)
        {
            var message= new { Name = $"Producer {count}", Message = $"Hello from producer {count}" };
            var body=Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish("demo-direct-exchange","account.init",basicProperties: null,body: body);

            Console.WriteLine($"Message {count} sent");
            Task.Delay(1000).Wait();
            count++;
        }

    }
 }
 