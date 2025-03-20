using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace RealTimeApp.Hubs
{
    //collection Connected client
    public class ChatHub:Hub
    {

        //RPC
        static Dictionary<string, string> ClientsIDs;

        public void NewMessageArrive(string name,string msg )//,List<string>)
        {
            
            //log ad in db
            //Clients.AllExcept(Context.ConnectionId).SendAsync("NewMessageNotify", name, msg);
            Clients.All.SendAsync("NewMessageNotify", name, msg);
        }

        //[Authorize]
        public override Task OnConnectedAsync()
        {
            string name = "Marly";// Context.User.Identity.Name;
            Clients.All.SendAsync("UserConnected", $"User {name} Connect");
            //Context
            //ClientsIDs[name] = Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
