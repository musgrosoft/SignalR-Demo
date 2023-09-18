using Microsoft.AspNetCore.SignalR;
using WebApplication3.Hub;

namespace WebApplication3
{
    public interface IMyHubHelper
    {
        void SendOutAlert(String groupName, string message);
    }

    //This wrapper for the HubContext only exists for use with Hangfire, it wouldn't be needed otherwise
    //Hangfire only exists to schedule fake future messages - to pretend progress is gradually being made on cover letter
    public class MyHubHelper : IMyHubHelper
    {
        private readonly IHubContext<ChatSampleHub> _hubContext;

        public MyHubHelper(IHubContext<ChatSampleHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        public void SendOutAlert(String groupName, string message)
        {
            _hubContext.Clients.Group(groupName).SendAsync("broadcastMessage", $"Hi {groupName} the server says",
                $"The time is {DateTime.Now}" + " " + message);


        }
    }
}
