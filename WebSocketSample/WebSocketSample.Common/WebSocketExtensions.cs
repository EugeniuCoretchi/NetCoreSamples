using System.Net.WebSockets;
using System.Text;


namespace WebSocketSample.Common
{
    public static class WebSocketExtensions
    {
        public static Task SendAsync(this WebSocket ws, string message, Action? onAborted = null)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
            if (ws.State == WebSocketState.Open)
            {
                return ws.SendAsync(arraySegment,
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            }

            if (ws.State == WebSocketState.Closed || ws.State == WebSocketState.Aborted)
            {
                onAborted?.Invoke();
            }

            return Task.CompletedTask;
        }
    }
}
