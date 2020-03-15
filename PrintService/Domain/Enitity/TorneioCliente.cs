using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class TorneioCliente
    {
        public long Id { get; set; }
        public int IdTorneio { get; set; }
        public virtual Torneio Torneio { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string BonusBeneficente { get; set; }
        public short? BuyIn { get; set; }
        public short? ReBuy { get; set; }
        public short? Addon { get; set; }
        public short? JackPot { get; set; }
        public short? TaxaAdm { get; set; }
        public short? Jantar { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public virtual Usuario UsuarioCadastro { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }
        public long? IdComprovantePagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public double? ValorPago { get; set; }
        public short? BuyDouble { get; set; }
    }
}
