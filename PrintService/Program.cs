using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrintService;
using PrintService.Aplication;
using PrintService.Domain.Interface;
using PrintService.Infra;
using PrintService.Infra.Impressora;
using PrintService.Infra.Utils;

await Host.CreateDefaultBuilder(args)
.UseWindowsService()
.ConfigureServices((hostContext, services) =>
{
    hostContext.Configuration.Configure(hostContext.HostingEnvironment.IsProduction());
    services.AddScoped<IImpressaoAplicacao, ImpressaoAplicacao>();
    services.AddScoped<IImpressao, ImpressaoRingGame>();
    services.AddScoped<IImpressao, ImpressaoComprovante>();
    services.AddScoped<IImpressao, ImpressaoTorneioCliente>();
    services.AddScoped<IImpressao, ImpressaoVenda>();
    services.AddScoped<IRepository, Repository>();
    services.AddDbContext<IContext, Context>(ServiceLifetime.Scoped);
    services.AddHostedService<Worker>();
})
.Build()
.RunAsync();