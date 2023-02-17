using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Producer;
public static class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        TopicExchangePublisher.Publish(channel);
    }
}