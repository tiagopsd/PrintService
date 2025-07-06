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
            builder.ToTable("torneiocliente", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.BuyIn).HasColumnName("buyin").HasColumnType("int2");
            builder.Property(d => d.ReBuy).HasColumnName("rebuy").HasColumnType("int2");
            builder.Property(d => d.Addon).HasColumnName("addon").HasColumnType("int2");
            builder.Property(d => d.JackPot).HasColumnName("jackpot").HasColumnType("int2");
            builder.Property(d => d.Jantar).HasColumnName("jantar").HasColumnType("int2");
            builder.Property(d => d.TaxaAdm).HasColumnName("taxaadm").HasColumnType("int2");
            builder.Property(d => d.BonusBeneficente).HasColumnName("bonusbeneficente").HasColumnType("varchar").HasMaxLength(30);
            builder.Property(d => d.DataCadastro).HasColumnName("datacadastro").HasColumnType("timestamp").IsRequired();
            builder.Property(d => d.ValorPago).HasColumnName("valorpago").HasColumnType("numeric").HasPrecision(12, 2).IsRequired();
            builder.Property(d => d.BuyDouble).HasColumnName("buydouble").HasColumnType("int2");
            builder.Property(d => d.Situacao).HasColumnName("situacao").HasColumnType("int2");

            builder.Property(d => d.IdTorneio).HasColumnName("idtorneio").HasColumnType("int8");
            builder.Property(d => d.IdCliente).HasColumnName("idcliente").HasColumnType("int8");
            builder.Property(d => d.IdComprovantePagamento).HasColumnName("idcomprovantepagamento").HasColumnType("int8");

            builder.HasOne(d => d.Torneio).WithMany().HasForeignKey(d => d.IdTorneio);
            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.HasOne(d => d.Pagamento).WithMany(d => d.TorneiosClientes).HasForeignKey(d => d.IdComprovantePagamento);

        }
    }
}
