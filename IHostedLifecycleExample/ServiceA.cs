using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IHostedLifecycleExample
{
    public class ServiceA: IHostedService, IHostedLifecycleService
    {
        private readonly ILogger<ServiceA> logger;

        public ServiceA(ILogger<ServiceA> logger)
        {
            this.logger = logger;
        }

        public Task StartingAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting Async");

            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Start Async");
            _ = DoWork();
            return Task.CompletedTask;
        }

        public Task StartedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StoppingAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StoppedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public async Task DoWork(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            logger.LogInformation("Started DoWork");
            await Task.Delay(5000);
            Environment.Exit(0);
        }
    }
}
