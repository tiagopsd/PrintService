using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;

namespace PrintService.Domain.Enitity
{
    public class CashGame : IEntidade<long>, IConversorModeloImpressao
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public long IdComprovantePagamento { get; set; }

        public IModeloImpressao ConverteModeloImpressao() => (RingGameModelo)this;
    }
}
