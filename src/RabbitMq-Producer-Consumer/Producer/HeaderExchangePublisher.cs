using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class HeaderExchangePublisher 
 {
    private static int count;

    public static void Publish(IModel channel)
    {
        var ttl= new Dictionary<string, object>
        {
            {"x-message-ttl",30000}
        };

        channel.ExchangeDeclare("demo-header-exchange",ExchangeType.Headers,arguments: ttl);

        while(true)
        {
            var message= new { Name = $"Producer {count}", Message = $"Hello from producer {count}" };
            var body=Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            
            var properties=channel.CreateBasicProperties();
            properties.Headers=new Dictionary<string, object>
            {
                {"account","new"}
            };

            channel.BasicPublish("demo-header-exchange",string.Empty,basicProperties: properties,body: body);

            Console.WriteLine($"Message {count} sent");
            Task.Delay(1000).Wait();
            count++;
        }

    }
 }
 