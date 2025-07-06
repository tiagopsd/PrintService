using PrintService.Domain.Enitity;

namespace PrintService.Domain.Model
{
    public class TorneioModelo
    {
        public string Nome { get; set; }
        public decimal BuyDouble { get; set; }
        public decimal BuyIn { get; set; }
        public decimal ReBuy { get; set; }
        public decimal Addon { get; set; }
        public decimal JackPot { get; set; }
        public decimal TaxaAdm { get; set; }
        public decimal Jantar { get; set; }

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
