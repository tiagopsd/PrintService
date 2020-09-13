using PrintService.Domain.Enitity;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintService.Domain.Model
{
    public class ComprovanteModelo : IModeloImpressao
    {
        public List<RingGameModelo> CashGames { get; set; }
        public List<VendaModelo> Vendas { get; set; }
        public List<TorneioClienteModelo> TorneiosCliente { get; set; }
        public List<ParcelamentoPagamentoModelo> ParcelamentoPagamentos { get; set; }
        public PagamentoModelo Pagamento { get; set; }
        public Cliente Cliente { get; set; }

        public static explicit operator ComprovanteModelo(Pagamento pagamento) => 
            pagamento == null ? null : new ComprovanteModelo
            {
                CashGames = pagamento.CashGames.Select(d => (RingGameModelo)d).ToList(),
                Vendas = pagamento.Vendas.Select(d => (VendaModelo)d).ToList(),
                TorneiosCliente = pagamento.TorneiosClientes.Select(d => (TorneioClienteModelo)d).ToList(),
                Cliente = pagamento.Cliente,
                Pagamento = (PagamentoModelo)pagamento,
                ParcelamentoPagamentos = pagamento.ParcelamentoPagamentos.Select(d => (ParcelamentoPagamentoModelo)d).ToList(),
            };
    }
}
