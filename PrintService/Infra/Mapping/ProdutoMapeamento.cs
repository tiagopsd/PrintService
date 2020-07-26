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
            builder.ToTable("Produto", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            builder.Property(d => d.Valor).HasColumnType("float").IsRequired();
        }
    }
}
