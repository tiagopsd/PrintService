using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrintService.Domain;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            
            dbContextOptionsBuilder
                .UseSqlServer(configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Impressao>();
        }
    }
}
