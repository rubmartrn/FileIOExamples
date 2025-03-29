using Microsoft.AspNetCore.SignalR;

namespace UniversityProgram.Api.Hubs
{
    public class StudentHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}
