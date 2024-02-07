using WebSocketSample;
using System.Net.WebSockets;
using System.Text;
using WebSocketSample.Common;


var ws = new ClientWebSocket();
Console.WriteLine("Connecting to server ...");
await ws.ConnectAsync(new Uri("ws://localhost:6969/ws"), CancellationToken.None);
Console.WriteLine("Connected!");


var worker = new WsWorker(ws);

await Task.Delay(1000);
await ws.SendAsync("message some 1");
await ws.SendAsync("ping");
await Task.Delay(1000);
await ws.SendAsync("message some 2");
await ws.SendAsync("ping");
await Task.Delay(1000);
await ws.SendAsync("message some 3");
await ws.SendAsync("ping");

await worker.WaitAsync();