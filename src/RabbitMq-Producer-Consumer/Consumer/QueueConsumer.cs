using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class QueueConsumer
 {
    public static void Consume(IModel channel)
    {
     channel.QueueDeclare("demo-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null
                             );
                             
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
 
