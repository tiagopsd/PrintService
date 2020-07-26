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
            builder.ToTable("Venda", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.DataVenda).HasColumnType("datetime2").IsRequired();
            builder.Property(d => d.Situacao).HasColumnType("smallint").IsRequired();
            builder.Property(d => d.Valor).HasColumnType("float").IsRequired();
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente).IsRequired();
            builder.HasOne(d => d.Pagamento).WithMany(d => d.Vendas).HasForeignKey(d => d.IdComprovantePagamento);
            builder.HasMany(d => d.PreVendas).WithOne(d => d.Venda);
        }
    }
}
