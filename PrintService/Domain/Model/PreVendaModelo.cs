using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class PreVendaModelo
    {
        public int Quantidade { get; set; }
        public ProdutoModelo Produto { get; set; }

        public static explicit operator PreVendaModelo(PreVenda preVenda)
            => preVenda == null ? null : new PreVendaModelo
            {
                Produto = (ProdutoModelo)preVenda.Produto,
                Quantidade = preVenda.Quantidade,
            };
    }
}
