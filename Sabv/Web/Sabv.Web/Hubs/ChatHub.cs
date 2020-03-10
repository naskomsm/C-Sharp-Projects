namespace Sabv.Web.Hubs
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using Sabv.Data.Models;

    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await this.Clients.All.SendAsync("receiveMessage", message);
    }
}
