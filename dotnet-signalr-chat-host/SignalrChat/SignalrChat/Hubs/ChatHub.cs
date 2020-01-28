using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalrChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
