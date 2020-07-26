using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class CashGameMapeamento : IEntityTypeConfiguration<CashGame>
    {
        public void Configure(EntityTypeBuilder<CashGame> builder)
        {
            builder.ToTable("CashGame","dbo");
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.Property(d => d.DataCadastro).HasColumnType("datetime2").IsRequired();
            builder.Property(d => d.Valor).HasColumnType("float").IsRequired();
            builder.Property(d => d.Situacao).HasColumnType("smallint").IsRequired();
            builder.HasOne(d => d.Pagamento).WithMany(d => d.CashGames).HasForeignKey(d => d.IdComprovantePagamento);
        }
    }
}
