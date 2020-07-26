using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class CashGame : IEntidade<int>
    {
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public long IdComprovantePagamento { get; set; }

        public IModeloImpressao ConverteModeloImpressao() => (CashGameModelo)this;
    }
}
