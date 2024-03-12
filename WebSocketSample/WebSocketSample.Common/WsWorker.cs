using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;


namespace WebSocketSample.Common
{
    public class WsWorker
    {
        readonly byte[] buffer = new byte[10240];

        private static int clientNum = 0;

        private Task receiveTask;

        public WsWorker(WebSocket ws)
        {
            clientNum++;
            Console.WriteLine($"Client accepted: {clientNum}:{ws.GetHashCode()}");
            receiveTask = Task.Run(async () =>
            {
                while (true)
                {
                    var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine($"Client close connection");
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($">rcv: {message}");
                    if (message == "ping")
                    {
                        Console.WriteLine("sending pong ...");
                        await ws.SendAsync("pong");
                    }
                }
            });
        }

        public void Wait() => receiveTask.Wait();
        public Task WaitAsync() => receiveTask;
    }
}
