using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;

namespace PrintService.Infra.Mapping
{
    public class CashGameMapeamento : IEntityTypeConfiguration<CashGame>
    {
        public void Configure(EntityTypeBuilder<CashGame> builder)
        {
            builder.ToTable("cashgame", "public");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id").HasColumnType("int8").IsRequired();

            builder.Property(d => d.DataCadastro).HasColumnName("datacadastro").HasColumnType("timestamp").IsRequired();
            builder.Property(d => d.Valor).HasColumnName("valor").HasColumnType("numeric").HasPrecision(12, 2).IsRequired();
            builder.Property(d => d.Situacao).HasColumnName("situacao").HasColumnType("int2").IsRequired();

            builder.Property(d => d.IdCliente).HasColumnName("idcliente").HasColumnType("int8");
            builder.Property(d => d.IdComprovantePagamento).HasColumnName("idcomprovantepagamento").HasColumnType("int8");

            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(d => d.IdCliente);
            builder.HasOne(d => d.Pagamento).WithMany(d => d.CashGames).HasForeignKey(d => d.IdComprovantePagamento);
        }
    }
}
