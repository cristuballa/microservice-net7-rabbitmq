using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class QueueProducer 
 {
    private static int count;

    public static void Publish(IModel channel)
    {
            channel.QueueDeclare("demo-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null
                             );
        while(true)
        {
            var message= new { Name = $"Producer {count}", Message = $"Hello from producer {count}" };
            var body=Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish("","demo-queue",basicProperties: null,body: body);
            Console.WriteLine($"Message {count} sent");
            Task.Delay(1).Wait();
            count++;
        }

    }
 }
 
