using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace signalR.hub
{
    public class Hubs : Hub
    {
        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
        public async Task SendMessageGroup(string roomName, string user, string message)
        {
            await Clients.Groups(roomName).SendAsync("ReceiveMessage", user, message);
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}