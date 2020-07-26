using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class PreVenda : IEntidade
    {
        public long Id { get; set; }
        public short Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public virtual Venda Venda { get; set; }
        public long IdVenda { get; set; }
    }
}
