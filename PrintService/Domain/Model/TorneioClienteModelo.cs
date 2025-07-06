using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Infra.Utils;
using System;

namespace PrintService.Domain.Model
{
    public class TorneioClienteModelo : IModeloImpressao
    {
        public DateTime DataCadastro { get; set; }
        public short BuyDouble { get; set; }
        public TorneioModelo Torneio { get; set; }
        public short BuyIn { get; set; }
        public short ReBuy { get; set; }
        public short Addon { get; set; }
        public short JackPot { get; set; }
        public short TaxaAdm { get; set; }
        public string BonusBeneficente { get; set; }
        public short Jantar { get; set; }
        public decimal ValorTotal { get; set; }
        public ClienteModelo Cliente { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public decimal ValorPago { get; set; }

        public static explicit operator TorneioClienteModelo(TorneioCliente torneioCliente) =>
            torneioCliente == null ? null : new TorneioClienteModelo
            {
                Addon = torneioCliente.Addon ?? 0,
                BonusBeneficente = torneioCliente.BonusBeneficente,
                BuyDouble = torneioCliente.BuyDouble ?? 0,
                BuyIn = torneioCliente.BuyIn ?? 0,
                Cliente = (ClienteModelo)torneioCliente.Cliente,
                DataCadastro = torneioCliente.DataCadastro,
                JackPot = torneioCliente.JackPot ?? 0,
                Jantar = torneioCliente.Jantar ?? 0,
                ReBuy = torneioCliente.ReBuy ?? 0,
                Situacao = torneioCliente.Situacao,
                TaxaAdm = torneioCliente.TaxaAdm ?? 0,
                Torneio = (TorneioModelo)torneioCliente.Torneio,
                ValorPago = torneioCliente.ValorPago ?? 0,
                ValorTotal = CalculaValorTotal(torneioCliente)
            };

        public static decimal CalculaValorTotal(TorneioCliente torneioCliente) =>
            (torneioCliente.Torneio.Addon * torneioCliente?.Addon ?? 0) +
            (torneioCliente.Torneio.BuyDouble * torneioCliente?.BuyDouble ?? 0) +
            (torneioCliente.Torneio.BuyIn * torneioCliente?.BuyIn ?? 0) +
            (torneioCliente.Torneio.JackPot * torneioCliente?.JackPot ?? 0) +
            (torneioCliente.Torneio.Jantar * torneioCliente?.Jantar ?? 0) +
            (torneioCliente.Torneio.ReBuy * torneioCliente?.ReBuy ?? 0) +
            (torneioCliente.Torneio.TaxaAdm * torneioCliente?.TaxaAdm ?? 0) +
            (torneioCliente.BonusBeneficente.HasValue() && torneioCliente.BonusBeneficente.Contains("5") ? 5 : 0);
    }
}
