
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class DirectExchangeConsumer
 {
    public static void Consume(IModel channel)
    {
     channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);
     channel.QueueDeclare("demo-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null
                             );
     channel.QueueBind("demo-queue", "demo-direct-exchange", "account.init");
     channel.BasicQos(0, 10, false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received {0}", message);
        };
        channel.BasicConsume("demo-queue", true, consumer);
        Console.ReadLine();
    }
 }
 
