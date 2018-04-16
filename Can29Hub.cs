using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;


namespace ServiceSample
{
    public class Can29Hub : Hub
    {
        public void Send(string propertyname, int value)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("BroadcastMessage", propertyname, value);
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