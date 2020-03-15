using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class CashGame
    {
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public virtual Usuario UsuarioCadastro { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public long? IdComprovantePagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
    }
}
