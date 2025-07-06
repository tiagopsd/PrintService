using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class VendaMapeamento : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("venda", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.DataVenda).HasColumnName("datavenda").HasColumnType("timestamp").IsRequired();
            builder.Property(d => d.Situacao).HasColumnName("situacao").HasColumnType("int2").IsRequired();
            builder.Property(d => d.Valor).HasColumnName("valor").HasColumnType("numeric").HasPrecision(12, 2).IsRequired();

            builder.Property(d => d.IdCliente).HasColumnName("idcliente").HasColumnType("int8");
            builder.Property(d => d.IdComprovantePagamento).HasColumnName("idcomprovantepagamento").HasColumnType("int8");

            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.HasOne(d => d.Pagamento).WithMany(d => d.Vendas).HasForeignKey(d => d.IdComprovantePagamento);
            builder.HasMany(d => d.PreVendas).WithOne(d => d.Venda);
        }
    }
}
