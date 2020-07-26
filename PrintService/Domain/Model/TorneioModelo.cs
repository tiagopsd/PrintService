using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class TorneioModelo
    {
        public string Nome { get; set; }
        public double BuyDouble { get; set; }
        public double BuyIn { get; set; }
        public double ReBuy { get; set; }
        public double Addon { get; set; }
        public double JackPot { get; set; }
        public double TaxaAdm { get; set; }
        public object Jantar { get; set; }

        public static explicit operator TorneioModelo(Torneio torneio) =>
            torneio == null ? null : new TorneioModelo
            {
                Addon = torneio.Addon ?? 0,
                BuyDouble = torneio.BuyDouble ?? 0,
                BuyIn = torneio.BuyIn ?? 0,
                JackPot = torneio.JackPot ?? 0,
                Jantar = torneio.Jantar ?? 0,
                Nome = torneio.Nome,
                ReBuy = torneio.ReBuy ?? 0,
                TaxaAdm = torneio.TaxaAdm ?? 0
            };
    }
}
