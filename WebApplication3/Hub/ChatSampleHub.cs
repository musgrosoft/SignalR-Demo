namespace WebApplication3.Hub;

using Microsoft.AspNetCore.SignalR;
public class ChatSampleHub : Hub
{
    // public Task BroadcastMessage(string name, string message) =>
    //     //1min
    //     Clients.All.SendAsync("broadcastMessage", name, message);

    //public Task Echo(string name, string message) =>
    //    Clients.Client(Context.ConnectionId)
    //        .SendAsync("echo", name, $"{message} (echo from server)");

    //public async Task BuildMyCV(string userName, string message)
    //{


    //    await Clients.Group(userName).SendAsync("broadcastMessage","The server says", message) ;
    //}


    public Task AddToGroup(string userName)
    {
        //Pretend that user has authenticated (i.e. one user cannot pretend to be another - your messages are private to you)

        if (!String.IsNullOrEmpty(userName))
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, userName);
        }

        return Task.CompletedTask;
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    
}