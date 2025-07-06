using PrintService.Domain.Interface;

namespace PrintService.Domain.Enitity
{
    public class Produto : IEntidade<long>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
