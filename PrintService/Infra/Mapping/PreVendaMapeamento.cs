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
            builder.ToTable("PreVenda", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Quantidade).HasColumnType("smallint").IsRequired();
            builder.HasOne(d => d.Produto).WithMany().HasForeignKey(d => d.IdProduto);
            builder.HasOne(d => d.Venda).WithMany(d => d.PreVendas).HasForeignKey(d => d.IdVenda);
        }
    }
}
