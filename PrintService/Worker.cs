using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrintService.Aplication;
using PrintService.Domain.Interface;

namespace PrintService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IImpressaoAplicacao _impressaoAplicacao;
        public Worker(ILogger<Worker> logger, IImpressaoAplicacao impressaoAplicacao)
        {
            _logger = logger;
            _impressaoAplicacao = impressaoAplicacao;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _impressaoAplicacao.Processar();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
