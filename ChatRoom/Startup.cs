using ChatRoom.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatRoom.Startup))]

namespace ChatRoom
{
    public class Startup
    {
        private static ChatModel chatApp;
        public static ChatModel ChatApp
        {
            get { return chatApp; }
        }

        public Startup()
        {
            chatApp = new ChatModel();
        }
        
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
