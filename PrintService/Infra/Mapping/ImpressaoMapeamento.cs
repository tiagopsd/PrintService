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
            builder.ToTable("impressao", "public");
           
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.IdObjetoImpressao).HasColumnName("idobjetoimpressao").HasColumnType("int8");
            builder.Property(d => d.NomeImpressora).HasColumnName("nomeimpressora").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(d => d.TipoImpressao).HasColumnName("tipoimpressao").HasColumnType("int2");
            builder.Property(d => d.SituacaoImpressao).HasColumnName("situacaoimpressao").HasColumnType("int2");
        }
    }
}
