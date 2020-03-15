using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrintService.Infra
{
    public class ImpressaoMapeamento : IEntityTypeConfiguration<Impressao>
    {
        public void Configure(EntityTypeBuilder<Impressao> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.IdObjetoImpressao).HasColumnType("bigint");
            builder.Property(d => d.NomeImpressora).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(d => d.TipoImpressao).HasColumnType("smallint");
            builder.Property(d => d.SituacaoImpressao).HasColumnType("smallint");
        }
    }
}
