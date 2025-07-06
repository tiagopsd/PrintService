using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class PreVendaMapeamento : IEntityTypeConfiguration<PreVenda>
    {
        public void Configure(EntityTypeBuilder<PreVenda> builder)
        {
            builder.ToTable("prevenda", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.Quantidade).HasColumnName("quantidade").HasColumnType("int2").IsRequired();

            builder.Property(d => d.IdProduto).HasColumnName("idproduto").HasColumnType("int8");
            builder.Property(d => d.IdVenda).HasColumnName("idvenda").HasColumnType("int8");

            builder.HasOne(d => d.Produto).WithMany().HasForeignKey(d => d.IdProduto);
            builder.HasOne(d => d.Venda).WithMany(d => d.PreVendas).HasForeignKey(d => d.IdVenda);
        }
    }
}
