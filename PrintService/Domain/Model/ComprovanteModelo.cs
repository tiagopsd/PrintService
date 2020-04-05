using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class ComprovanteModelo
    {
        public string NomeCliente { get; set; }
        public DateTime DataPagamento { get; set; }
        public List<CashGameModelo> CashGames { get; set; }
        public List<VendaModelo> Vendas { get; set; }
        public List<TorneioClienteModelo> TorneiosCliente { get; set; }
    }
}
