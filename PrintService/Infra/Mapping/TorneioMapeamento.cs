using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class TorneioMapeamento : IEntityTypeConfiguration<Torneio>
    {
        public void Configure(EntityTypeBuilder<Torneio> builder)
        {
            builder.ToTable("torneio", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.Nome).HasColumnName("nome").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(d => d.BuyIn).HasColumnName("buyin").HasColumnType("numeric").HasPrecision(12, 2);
            builder.Property(d => d.ReBuy).HasColumnName("rebuy").HasColumnType("numeric").HasPrecision(12, 2);
            builder.Property(d => d.Addon).HasColumnName("addon").HasColumnType("numeric").HasPrecision(12, 2);
            builder.Property(d => d.JackPot).HasColumnName("jackpot").HasColumnType("numeric").HasPrecision(12, 2);
            builder.Property(d => d.Jantar).HasColumnName("jantar").HasColumnType("numeric").HasPrecision(12, 2);
            builder.Property(d => d.TaxaAdm).HasColumnName("taxaadm").HasColumnType("numeric").HasPrecision(12, 2);
            builder.Property(d => d.BuyDouble).HasColumnName("buydouble").HasColumnType("numeric").HasPrecision(12, 2);
        }
    }
}
