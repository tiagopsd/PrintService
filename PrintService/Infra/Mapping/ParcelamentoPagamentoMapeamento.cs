using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class ParcelamentoPagamentoMapeamento : IEntityTypeConfiguration<ParcelamentoPagamento>
    {
        public void Configure(EntityTypeBuilder<ParcelamentoPagamento> builder)
        {
            builder.ToTable("ParcelamentoPagamento", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.TipoFinalizador).HasColumnType("smallint").IsRequired();
            builder.Property(d => d.ValorPago).HasColumnType("float").IsRequired();
            builder.Property(d => d.DataPagamento).HasColumnType("datetime").IsRequired();
            builder.HasOne(d => d.Pagamento).WithMany(d => d.ParcelamentoPagamentos).HasForeignKey(d => d.IdComprovantePagamento);

        }
    }
}
