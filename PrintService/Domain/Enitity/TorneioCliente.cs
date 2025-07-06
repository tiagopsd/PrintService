using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;

namespace PrintService.Domain.Enitity
{
    public class TorneioCliente : IEntidade<long>, IConversorModeloImpressao
    {
        public long Id { get; set; }
        public long IdTorneio { get; set; }
        public virtual Torneio Torneio { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string BonusBeneficente { get; set; }
        public short? BuyIn { get; set; }
        public short? ReBuy { get; set; }
        public short? Addon { get; set; }
        public short? JackPot { get; set; }
        public short? TaxaAdm { get; set; }
        public short? Jantar { get; set; }
        public DateTime DataCadastro { get; set; }
        public long? IdComprovantePagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public decimal? ValorPago { get; set; }
        public short? BuyDouble { get; set; }
        public SituacaoVenda Situacao { get; set; }

        public IModeloImpressao ConverteModeloImpressao() => (TorneioClienteModelo)this;
    }
}
