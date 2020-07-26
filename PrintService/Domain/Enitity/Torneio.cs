using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Torneio : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double? BuyIn { get; set; }
        public double? ReBuy { get; set; }
        public double? Addon { get; set; }
        public double? Jantar { get; set; }
        public double? JackPot { get; set; }
        public double? TaxaAdm { get; set; }
        public double? BuyDouble { get; set; }
    }
}
