using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Producer;
public static class Program
{
    private static void Main(string[] args)
    {
        var count = 0;
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
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