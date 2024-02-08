using System.Collections.Concurrent;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqRPCClient;


var clientID = "FR00045";
var rpcQueueName = $"rpc_queue_{clientID}";
using var rpcClient = new RpcClient(rpcQueueName);

Console.WriteLine("RPC Client");


do
{
    Console.Write("> ");
    var cmd = Console.ReadLine();

    if (cmd == "quit" || cmd == "exit")
        return;

    await InvokeAsync(cmd);

} while (true);


async Task InvokeAsync(string message)
{
    var response = await rpcClient.CallAsync(message);

    Console.WriteLine($" [.] < {response}");
}