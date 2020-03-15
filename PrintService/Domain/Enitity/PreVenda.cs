using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class PreVenda
    {
        public long Id { get; set; }
        public short Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public DateTime DataHora { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public long? IdVenda { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
