using PrintService.Domain.Interface;

namespace PrintService.Domain.Enitity
{
    public class PreVenda : IEntidade<long>
    {
        public long Id { get; set; }
        public short Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public long IdProduto { get; set; }
        public virtual Venda Venda { get; set; }
        public long IdVenda { get; set; }
    }
}
