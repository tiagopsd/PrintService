using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.Login).HasColumnName("login").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(d => d.Nome).HasColumnName("nome").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(d => d.Senha).HasColumnName("senha").HasColumnType("varchar").HasMaxLength(10).IsRequired();
        }
    }
}
