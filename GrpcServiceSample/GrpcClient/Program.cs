using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new Greeter.GreeterClient(channel);

Console.WriteLine("sending SayHelloAsync to gRPC server >> ");
var reply = await client.SayHelloAsync( new HelloRequest { Name = "GreeterClient" } );

Console.WriteLine("reply >> " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();