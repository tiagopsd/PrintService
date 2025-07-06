using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class PagamentoMapeamento : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("pagamento", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.Data).HasColumnName("data").HasColumnType("timestamp").IsRequired();
            builder.Property(d => d.ValorTotal).HasColumnType("numeric").HasPrecision(12, 2).IsRequired();

            builder.Property(d => d.IdCliente).HasColumnName("idcliente").HasColumnType("int8");
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            
            builder.HasMany(d => d.CashGames).WithOne(d => d.Pagamento);
            builder.HasMany(d => d.Vendas).WithOne(d => d.Pagamento);
            builder.HasMany(d => d.TorneiosClientes).WithOne(d => d.Pagamento);
            builder.HasMany(d => d.ParcelamentoPagamentos).WithOne(d => d.Pagamento);
        }
    }
}
