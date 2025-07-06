using PrintService.Domain.Interface;

namespace PrintService.Domain.Enitity
{
    public class Cliente : IEntidade<long>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
