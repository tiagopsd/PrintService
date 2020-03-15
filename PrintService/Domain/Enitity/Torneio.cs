using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Torneio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double? BuyIn { get; set; }
        public double? ReBuy { get; set; }
        public double? Addon { get; set; }
        public double? Jantar { get; set; }
        public double? JackPot { get; set; }
        public double? TaxaAdm { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public virtual Usuario UsuarioCadastro { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }
        public double? BuyDouble { get; set; }
    }
}
