using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RealTimeApp.DTO;

namespace RealTimeApp.Hubs
{
    //collection Connected client
    public class ChatHub:Hub
    {

        //RPC
        static Dictionary<string, string> ClientsIDs;
        //{name:ahemd ,txt:hello}
        public void NewMessageArrive(ChatMEssageDetails details)//string name,string msg )//,List<string>)
        {
            //log ad in db
            //Clients.AllExcept(Context.ConnectionId).SendAsync("NewMessageNotify", name, msg);
            Clients.All.SendAsync("NewMessageNotify", details);// details.name, details.text);
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
