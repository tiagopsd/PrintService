using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrintService.Aplication;
using PrintService.Domain.Interface;
using PrintService.Infra;
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
                
                _serviceProvider
                    .CreateScope()
                    .ServiceProvider.GetService<IImpressaoAplicacao>()
                    .Processar();

                var tempo = Configuracao.ObterConfiguracao<int>("Tempo");
                await Task.Delay(tempo, stoppingToken);
            }
        }
    }
}
