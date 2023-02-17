using System.Text;
using Producer;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

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
        HeaderExchangeConsumer.Consume(channel);      
     }
}