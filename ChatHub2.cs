//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ServiceSample
{
    public interface ISimpleClient
    {
        void BroadcastMessage(string name, string message);
    }

    public class ChatHub2 : Hub<ISimpleClient>
    {
        public void Send(string name, string message)
        {
            Clients.All.BroadcastMessage(name, message);
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
