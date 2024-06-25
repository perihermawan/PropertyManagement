using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace propertymanagement.service.Hubs
{
    public class NotificationHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendMessage(string author, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", author, message);
        }
    }
}
