using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory();

factory.UserName = "ngpoyrsc";
factory.Password = "BoApMfV8Eot8-sKeh3xi9bz-5YUb0M26";
factory.Uri = new Uri("amqps://ngpoyrsc:BoApMfV8Eot8-sKeh3xi9bz-5YUb0M26@cow.rmq2.cloudamqp.com/ngpoyrsc");

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

// declare a server-named queue
var queueName = "log-queue";// channel.QueueDeclare().QueueName;
    //channel.QueueBind(queue: queueName,
    //                  exchange: "logs",
    //                  routingKey: string.Empty);

    //Console.WriteLine($" [*] Waiting for logs. QueueName: {queueName}");

    //var consumer = new EventingBasicConsumer(channel);
    //consumer.Received += (model, ea) =>
    //{
    //    byte[] body = ea.Body.ToArray();
    //    var message = Encoding.UTF8.GetString(body);
    //    Console.WriteLine($" [x] {message}");
    //};
    //channel.BasicConsume(queue: queueName,
    //                     autoAck: true,
    //                     consumer: consumer);

var key = ConsoleKey.None;
while (key != ConsoleKey.Escape)
{
    Console.WriteLine(" Press [enter] to read message from queue.");
    key = Console.ReadKey().Key;
    if (key != ConsoleKey.Enter)
        continue;

    bool autoAck = false;
    BasicGetResult result = channel.BasicGet(queueName, autoAck);
    if (result == null)
    {
        Console.WriteLine(" No message available at this time.");
    }
    else
    {
        IBasicProperties props = result.BasicProperties;
        var body = result.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] {message}");

        // acknowledge receipt of the message
        channel.BasicAck(result.DeliveryTag, false);
    }
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();