
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class TopicExchangeConsumer
 {
    public static void Consume(IModel channel)
    {
     channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic);
     channel.QueueDeclare("demo-topic-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null
                             );
     channel.QueueBind("demo-topic-queue", "demo-topic-exchange", "account.*");
     channel.BasicQos(0, 10, false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received {0}", message);
        };
        channel.BasicConsume("demo-topic-queue", true, consumer);
        Console.ReadLine();
    }
 }
 
