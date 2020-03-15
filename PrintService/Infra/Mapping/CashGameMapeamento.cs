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
            builder.ToTable("CashGame");
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.HasOne(d => d.UsuarioCadastro).WithMany().HasForeignKey(d => d.IdUsuarioCadastro);
            builder.HasOne(d => d.UsuarioAlteracao).WithMany().HasForeignKey(d => d.IdUsuarioAlteracao);
            builder.Property(d => d.DataAlteracao).HasColumnType("datetime2");
            builder.Property(d => d.DataCadastro).HasColumnType("datetime2").IsRequired();
            builder.HasOne(d => d.Pagamento).WithMany().HasForeignKey(d => d.IdComprovantePagamento);
        }
    }
}
