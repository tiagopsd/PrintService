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
            builder.ToTable("Torneio", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(d => d.BuyIn).HasColumnType("float");
            builder.Property(d => d.ReBuy).HasColumnType("float");
            builder.Property(d => d.Addon).HasColumnType("float");
            builder.Property(d => d.JackPot).HasColumnType("float");
            builder.Property(d => d.Jantar).HasColumnType("float");
            builder.Property(d => d.TaxaAdm).HasColumnType("float");
            builder.Property(d => d.DataAlteracao).HasColumnType("datetime2");
            builder.Property(d => d.DataCadastro).HasColumnType("datetime2").IsRequired();
            builder.HasOne(d => d.UsuarioCadastro).WithMany().HasForeignKey(d => d.IdUsuarioCadastro);
            builder.HasOne(d => d.UsuarioAlteracao).WithMany().HasForeignKey(d => d.IdUsuarioAlteracao);
            builder.Property(d => d.BuyDouble).HasColumnType("float");
        }
    }
}
