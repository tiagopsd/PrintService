using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrintService.Aplication;
using PrintService.Domain.Interface;
using PrintService.Infra;

namespace PrintService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IImpressaoAplicacao, ImpressaoAplicacao>();
                    services.AddEntityFrameworkSqlServer()
                    .AddDbContext<IContext, Context>(ServiceLifetime.Singleton);
                });
    }
}