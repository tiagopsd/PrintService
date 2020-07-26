using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using System;

namespace PrintService.Domain.Enitity
{
    public class ParcelamentoPagamento : IEntidade
    {
        public long Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public TipoFinalizador TipoFinalizador { get; set; }
        public double ValorPago { get; set; }
        public long? IdComprovantePagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}
