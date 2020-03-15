using PrintService.Domain.Enum;
using System;

namespace PrintService.Domain.Enitity
{
    public class ParcelamentoPagamento
    {
        public long Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public TipoFinalizador TipoFinalizador { get; set; }
        public double ValorPago { get; set; }
        public long? IdPagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}
