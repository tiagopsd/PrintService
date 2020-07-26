using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class ParcelamentoPagamentoModelo
    {
        public DateTime DataPagamento { get; set; }
        public double ValorPago { get; set; }
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
