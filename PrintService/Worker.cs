using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrintService.Domain.Interface;
using PrintService.Infra.Utils;

namespace PrintService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Serviço rodando às: {time}", DateTimeOffset.Now);

                await _serviceProvider
                    .CreateScope()
                    .ServiceProvider.GetService<IImpressaoAplicacao>()
                    .Processar();

                await Task.Delay(AppSettings.LoopDelay, stoppingToken);
            }
        }
    }
}
