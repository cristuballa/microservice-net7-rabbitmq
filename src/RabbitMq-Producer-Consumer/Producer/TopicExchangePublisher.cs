using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class TopicExchangePublisher 
 {
    private static int count;

    public static void Publish(IModel channel)
    {
        var ttl= new Dictionary<string, object>
        {
            {"x-message-ttl",30000}
        };

        channel.ExchangeDeclare("demo-direct-exchange",ExchangeType.Direct,arguments: ttl);

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
 