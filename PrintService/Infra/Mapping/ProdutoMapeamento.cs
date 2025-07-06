using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.Nome).HasColumnName("nome").HasColumnType("varchar").HasMaxLength(80).IsRequired();
            builder.Property(d => d.Valor).HasColumnName("valor").HasColumnType("numeric").HasPrecision(12, 2).IsRequired();
        }
    }
}
