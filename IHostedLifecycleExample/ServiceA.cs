using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IHostedLifecycleExample
{
    public class ServiceA: IHostedLifecycleService
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

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Start Async");
            await DoWork();
        }

        public Task StartedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StoppingAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken) { return Task.CompletedTask; }

        public Task StoppedAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public async Task DoWork(CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Started DoWork");
            await Task.Delay(5000);
            Environment.Exit(0);
        }
    }
}
