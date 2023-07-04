using Microsoft.AspNetCore.SignalR;

namespace PizzaSystem.Application;
public class OrderHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("ReceiveMessage", "Start Message", DateTimeOffset.UtcNow);
        await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.Caller.SendAsync("ReceiveMessage", "End Message", DateTimeOffset.UtcNow);
        await base.OnDisconnectedAsync(exception);
    }
}