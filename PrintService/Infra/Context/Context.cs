using Microsoft.EntityFrameworkCore;
using PrintService.Domain.Interface;
using PrintService.Infra.Mapping;
using PrintService.Infra.Utils;

namespace PrintService.Infra
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {   
            dbContextOptionsBuilder
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging(!AppSettings.IsProduction)
                .UseNpgsql(AppSettings.ConnectionString.Decrypt());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
