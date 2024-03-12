using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;

using WebSocketSample.Common;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.WebHost.UseUrls("http://localhost:6969");

app.UseWebSockets();

//app.MapControllers();

app.Map("/ws", async context => 
{
    if(context.WebSockets.IsWebSocketRequest)
    {
        using var ws = await context.WebSockets.AcceptWebSocketAsync();

        try
        {
            await new WsWorker(ws).WaitAsync();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"Client abort connection: {ex.Message}");
        }
        catch (Exception x)
        {
            Console.WriteLine($"Unknown exception: {x.Message}");
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    } 
});
await app.RunAsync();
