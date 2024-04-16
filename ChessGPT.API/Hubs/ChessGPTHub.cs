using Microsoft.AspNetCore.SignalR;

namespace KB.ChessGPT.API.Hubs
{
    public class ChessGPTHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}