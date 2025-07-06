using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using System;

namespace PrintService.Domain.Model
{
    public class ParcelamentoPagamentoModelo
    {
        public DateTime DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public TipoFinalizador TipoFinalizador { get; set; }

        public static explicit operator ParcelamentoPagamentoModelo(ParcelamentoPagamento parcelamentoPagamento) =>
            parcelamentoPagamento == null ? null : new ParcelamentoPagamentoModelo
            {
                DataPagamento = parcelamentoPagamento.DataPagamento,
                TipoFinalizador = parcelamentoPagamento.TipoFinalizador,
                ValorPago = parcelamentoPagamento.ValorPago
            };
    }
}
