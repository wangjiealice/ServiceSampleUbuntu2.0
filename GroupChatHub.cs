//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ServiceSample
{
    public interface IGroupClient
    {
        void MessageToGroup(string groupName, string name, string message);
    }
    
    public class GroupChatHub : Hub<IGroupClient>
    {
        public Task AddGroup(string groupName) =>
            Groups.AddAsync(Context.ConnectionId, groupName);           


        public Task LeaveGroup(string groupName) =>
            Groups.RemoveAsync(Context.ConnectionId, groupName);


        public void Send(string group, string name, string message)
        {
            Clients.Group(group).MessageToGroup(group, name, message);
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
