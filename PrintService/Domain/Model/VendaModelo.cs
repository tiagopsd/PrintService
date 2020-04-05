using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class VendaModelo
    {
        public List<PreVendaModelo> PreVendas { get; internal set; }
        public DateTime DataVenda { get; internal set; }
        public decimal Valor { get; internal set; }
    }
}
