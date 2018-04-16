using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSample
{
    public class ChatHubMic : Hub
    {
        public Task SendMessage(string user, string message)
        {
            string timestamp = DateTime.Now.ToShortTimeString();
            return Clients.All.SendAsync("ReceiveMessage", timestamp, user, message);
        }
    }
}
