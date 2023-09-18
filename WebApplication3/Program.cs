using Hangfire;
using WebApplication3;
using WebApplication3.Hub;

var builder = WebApplication.CreateBuilder(args);


// Add Hangfire services.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseInMemoryStorage());


// Add the processing server as IHostedService
builder.Services.AddHangfireServer(option =>
{
    option.SchedulePollingInterval = TimeSpan.FromSeconds(1);
});



// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR(
    hubOptions =>
    {
        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
        hubOptions.ClientTimeoutInterval = TimeSpan.FromMinutes(1);
    }

).AddAzureSignalR();

//builder.Services.AddHostedService<TimedHostedService>();

builder.Services.AddScoped<IMyHubHelper, MyHubHelper>();
builder.Services.AddScoped<ICoverLetterGenerator, CoverLetterGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapHub<ChatSampleHub>("/chat");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
