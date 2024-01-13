using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory();

factory.UserName = "ngpoyrsc";
factory.Password = "BoApMfV8Eot8-sKeh3xi9bz-5YUb0M26";
factory.Uri = new Uri("amqps://ngpoyrsc:BoApMfV8Eot8-sKeh3xi9bz-5YUb0M26@cow.rmq2.cloudamqp.com/ngpoyrsc");

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

//channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

var message = GetMessage(args);

var msecSleep = new Random().Next(1000, 3000);

var counter = 0;
do
{
   
    var body = Encoding.UTF8.GetBytes($"{message}{counter}");
    channel.BasicPublish(exchange: "",
                         routingKey: "log-queue",
                         basicProperties: null,
                         body: body);

    Console.WriteLine($" [X-{counter}] Sent {message}");

    Thread.Sleep(msecSleep);
    counter++;
}

while (true);

static string GetMessage(string[] args)
{
    return ((args.Length > 0) ? string.Join(" ", args) : "MSG#");
}