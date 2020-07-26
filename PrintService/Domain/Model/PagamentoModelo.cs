using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class PagamentoModelo
    {
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }

        public static explicit operator PagamentoModelo(Pagamento pagamento) =>
            pagamento == null ? null : new PagamentoModelo
            {
                Data = pagamento.Data,
                ValorTotal = pagamento.ValorTotal
            };
    }
}
