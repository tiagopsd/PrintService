using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintService.Domain.Model
{
    public class VendaModelo : IModeloImpressao
    {
        public List<PreVendaModelo> PreVendas { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Valor { get; set; }
        public ClienteModelo Cliente { get; set; }
        public SituacaoVenda Situacao { get; set; }

        public static explicit operator VendaModelo(Venda venda)
            => venda == null ? null : new VendaModelo
            {
                Cliente = (ClienteModelo)venda.Cliente,
                DataVenda = venda.DataVenda,
                PreVendas = venda.PreVendas.Select(d => (PreVendaModelo)d).ToList(),
                Situacao = venda.Situacao,
                Valor = venda.Valor
            };
    }
}
