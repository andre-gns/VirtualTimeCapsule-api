using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualTimeCapsule.Api.Services
{
    public class MyBackgroundJobService : BackgroundService
    {
        private readonly ILogger<MyBackgroundJobService> _logger;

        public MyBackgroundJobService(ILogger<MyBackgroundJobService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MyBackgroundJobService está iniciando.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("MyBackgroundJobService executando em: {time}", DateTimeOffset.Now);

                // Coloque a lógica da sua tarefa agendada aqui
                // Por exemplo, uma chamada para a sua API, envio de e-mails, etc.
                // await RunMyScheduledTask();

                // Aguarda 5 segundos antes de executar novamente
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogInformation("MyBackgroundJobService está parando.");
        }
    }
}