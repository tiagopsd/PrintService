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
            builder.ToTable("parcelamentopagamento", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.TipoFinalizador).HasColumnName("tipofinalizador").HasColumnType("int2").IsRequired();
            builder.Property(d => d.ValorPago).HasColumnType("numeric").HasPrecision(12, 2).IsRequired();
            builder.Property(d => d.DataPagamento).HasColumnName("datapagamento").HasColumnType("timestamp").IsRequired();

            builder.Property(d => d.IdComprovantePagamento).HasColumnName("idcomprovantepagamento").HasColumnType("int8");
            builder.HasOne(d => d.Pagamento).WithMany(d => d.ParcelamentoPagamentos).HasForeignKey(d => d.IdComprovantePagamento);

        }
    }
}
