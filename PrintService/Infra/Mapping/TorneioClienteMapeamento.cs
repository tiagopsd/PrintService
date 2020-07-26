using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class TorneioClienteMapeamento : IEntityTypeConfiguration<TorneioCliente>
    {
        public void Configure(EntityTypeBuilder<TorneioCliente> builder)
        {
            builder.ToTable("TorneioCliente", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.BuyIn).HasColumnType("smallint");
            builder.Property(d => d.ReBuy).HasColumnType("smallint");
            builder.Property(d => d.Addon).HasColumnType("smallint");
            builder.Property(d => d.JackPot).HasColumnType("smallint");
            builder.Property(d => d.Jantar).HasColumnType("smallint");
            builder.Property(d => d.TaxaAdm).HasColumnType("smallint");
            builder.Property(d => d.BonusBeneficente).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(d => d.DataCadastro).HasColumnType("datetime2").IsRequired();
            builder.Property(d => d.ValorPago).HasColumnType("float").IsRequired();
            builder.HasOne(d => d.Torneio).WithMany().HasForeignKey(d => d.IdTorneio);
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.HasOne(d => d.Pagamento).WithMany(d => d.TorneiosClientes).HasForeignKey(d => d.IdComprovantePagamento);
            builder.Property(d => d.BuyDouble).HasColumnType("smallint");
            builder.Property(d => d.Situacao).HasColumnType("smallint");
        }
    }
}
