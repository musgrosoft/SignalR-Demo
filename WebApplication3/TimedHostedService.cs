// namespace WebApplication3;
// using Microsoft.AspNetCore.SignalR;
// using WebApplication3.Hub;
//
// public class TimedHostedService : IHostedService, IDisposable
// {
//
//     private Timer? _timer = null;
//     private Timer? _timer2 = null;
//     private readonly IHubContext<ChatSampleHub> _context;
//
//     public TimedHostedService(IHubContext<ChatSampleHub> context)
//     {
//         _context = context;
//     }
//
//     public Task StartAsync(CancellationToken stoppingToken)
//     {
//
//
//         _timer = new Timer(DoWork, "tim", TimeSpan.Zero, TimeSpan.FromSeconds(10));
//
//         _timer2 = new Timer(DoWork, "matt", TimeSpan.Zero, TimeSpan.FromSeconds(1));
//
//         return Task.CompletedTask;
//     }
//
//     private void DoWork(object? state)
//     {
//         // string groupName = "Matty.Matt@hotmail.com";
//         //
//          _context.Clients.Group((string)state).SendAsync("broadcastMessage", $"Hi {(string)state} The server saysz", $"the time is {DateTime.Now}");
//
//          _context.Clients.Group((string)state).SendAsync("broadcastMessage", $"Hi {(string)state} the server says",
//              $"Hi {(string)state} the server says the time is {DateTime.Now}" + " " );
//
//     }
//
//     public Task StopAsync(CancellationToken stoppingToken)
//     {
//
//
//         _timer?.Change(Timeout.Infinite, 0);
//
//         return Task.CompletedTask;
//     }
//
//     public void Dispose()
//     {
//         _timer?.Dispose();
//     }
// }