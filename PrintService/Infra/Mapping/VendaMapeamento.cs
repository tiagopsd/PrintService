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
            builder.Property(d => d.QtdItem).HasColumnType("smallint").IsRequired();
            builder.Property(d => d.DataVenda).HasColumnType("datetime2").IsRequired();
            builder.Property(d => d.Situacao).HasColumnType("smallint").IsRequired();
            builder.HasOne(d => d.Usuario).WithMany().HasForeignKey(d => d.IdUsuario);
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.HasOne(d => d.Pagamento).WithMany().HasForeignKey(d => d.IdComprovantePagamento);
        }
    }
}
