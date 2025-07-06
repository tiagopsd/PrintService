using PrintService.Domain.Enitity;
using System;

namespace PrintService.Domain.Model
{
    public class PagamentoModelo
    {
        public decimal ValorTotal { get; set; }
        public DateTime Data { get; set; }

        public static explicit operator PagamentoModelo(Pagamento pagamento) =>
            pagamento == null ? null : new PagamentoModelo
            {
                Data = pagamento.Data,
                ValorTotal = pagamento.ValorTotal
            };
    }
}
