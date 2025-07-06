using PrintService.Domain.Interface;

namespace PrintService.Domain.Enitity
{
    public class Torneio : IEntidade<long>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal? BuyIn { get; set; }
        public decimal? ReBuy { get; set; }
        public decimal? Addon { get; set; }
        public decimal? Jantar { get; set; }
        public decimal? JackPot { get; set; }
        public decimal? TaxaAdm { get; set; }
        public decimal? BuyDouble { get; set; }
    }
}
