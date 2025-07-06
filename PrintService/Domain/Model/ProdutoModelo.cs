using PrintService.Domain.Enitity;

namespace PrintService.Domain.Model
{
    public class ProdutoModelo
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public static explicit operator ProdutoModelo(Produto produto)
            => produto == null ? null : new ProdutoModelo
            {
                Nome = produto.Nome,
                Valor = produto.Valor
            };
    }
}
