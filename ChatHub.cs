using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;


namespace ServiceSample
{
    public class ChatHub : Hub
    {
        //public Task Send(string name, string message)
        //{
        //    string timestamp = DateTime.Now.ToShortTimeString();

        //    return Clients.All.SendAsync("ReceiveMessage", timestamp, name, message);
        //}

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("BroadcastMessage", name, message);

            //Clients.All.BroadcastMessage(name, message);
        }

        public override Task OnConnectedAsync()
        {
            // you can access info using base.Context
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}