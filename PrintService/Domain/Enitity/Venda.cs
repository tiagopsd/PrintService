using PrintService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Venda
    {
        public long Id { get; set; }
        public double Valor { get; set; }
        public short QtdItem { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public long? IdComprovantePagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public virtual ICollection<PreVenda> PreVendas { get; set; }
    }
}
