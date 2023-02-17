
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Producer;
public static class HeaderExchangeConsumer
 {
    public static void Consume(IModel channel)
    {
     channel.ExchangeDeclare("demo-header-exchange", ExchangeType.Topic);
     channel.QueueDeclare("demo-header-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null
                             );
   var header=new Dictionary<string, object>(){{"account", "new"}};

     channel.QueueBind("demo-header-queue", "demo-header-exchange",string.Empty,header);
     channel.BasicQos(0, 10, false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received {0}", message);
        };
        channel.BasicConsume("demo-header-queue", true, consumer);
        Console.ReadLine();
    }
 }
 
