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
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Login).HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(d => d.Nome).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(d => d.Senha).HasColumnType("varchar").HasMaxLength(10).IsRequired();
        }
    }
}
