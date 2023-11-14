using IHostedLifecycleExample;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHostBuilder builder = Host.CreateDefaultBuilder(args);
builder.ConfigureAppConfiguration((hostContext, configApp) =>
{
    configApp.AddJsonFile("appsettings.json", true);
})
.ConfigureLogging((context, b) => b.AddConsole())
.ConfigureServices((hostContext, services) =>
 {
     services.AddHostedService<ServiceA>();

 });
IHost host = builder.Build();
host.Run();

