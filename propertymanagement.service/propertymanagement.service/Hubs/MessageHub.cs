using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using propertymanagement.service.Models;


namespace propertymanagement.service.Hubs
{
    public class MessageHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public Task SendMessage(MessageNotifications messageNotification)
        {
            return Clients.All.SendAsync("Send", messageNotification);
        }
    }
}
