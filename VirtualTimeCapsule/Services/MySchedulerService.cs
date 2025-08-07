using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualTimeCapsule.Api.Services
{
    public class MySchedulerService : BackgroundService
    {
        private readonly ILogger<MySchedulerService> _logger;

        public MySchedulerService(ILogger<MySchedulerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MySchedulerService está iniciando.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("MySchedulerService executando em: {time}", DateTimeOffset.Now);

                 await RunMyScheduledTask();

                // Aguarda 5 segundos antes de executar novamente
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogInformation("MySchedulerService está parando.");
        }

        private async Task RunMyScheduledTask()
        {
            throw new NotImplementedException();
        }
    }
}