using Microsoft.AspNet.SignalR;
using ChatRoom.Models;
using System.Threading.Tasks;

namespace ChatRoom.Hubs
{
    public class ChatHub : Hub
    {
        public void send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);

            //Add to storage
            Startup.ChatApp.SaveMessage(name, Context.ConnectionId, message);
            
        }

        public void addUser(string name)
        {
            UserModel user = new UserModel(name, Context.ConnectionId);

            Clients.All.broadcastUserList(Startup.ChatApp.AddUser(user));
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.broadcastUserList(Startup.ChatApp.RemoveUser(Context.ConnectionId));

            return base.OnDisconnected(stopCalled);
        }
    }
}