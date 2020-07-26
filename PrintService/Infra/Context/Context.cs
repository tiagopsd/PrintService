using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using PrintService.Domain;
using PrintService.Domain.Interface;
using PrintService.Infra.Mapping;
using PrintService.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra
{
    public class Context : DbContext, IContext
    {
        private IServiceProvider _serviceProvider;
        public Context(DbContextOptions<Context> options, IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {   
            dbContextOptionsBuilder
                .UseLazyLoadingProxies()
                .UseInternalServiceProvider(_serviceProvider)
                .UseSqlServer(Configuracao.ObterConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImpressaoMapeamento());
            modelBuilder.ApplyConfiguration(new CashGameMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration(new PagamentoMapeamento());
            modelBuilder.ApplyConfiguration(new ParcelamentoPagamentoMapeamento());
            modelBuilder.ApplyConfiguration(new PreVendaMapeamento());
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new TorneioMapeamento());
            modelBuilder.ApplyConfiguration(new TorneioClienteMapeamento());
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new VendaMapeamento());
        }
    }
}
