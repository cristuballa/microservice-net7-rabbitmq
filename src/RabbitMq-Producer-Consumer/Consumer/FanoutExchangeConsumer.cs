
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class FanoutExchangeConsumer
{
    public static void Consume(IModel channel)
    {
        channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout);
        channel.QueueDeclare("demo-fanout-queue",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null
                                );

        channel.QueueBind("demo-fanout-queue", "demo-fanout-exchange", string.Empty);
        channel.BasicQos(0, 10, false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received {0}", message);
        };
        channel.BasicConsume("demo-fanout-queue", true, consumer);
        Console.ReadLine();
    }
}
