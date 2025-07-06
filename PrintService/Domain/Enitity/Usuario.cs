using PrintService.Domain.Interface;

namespace PrintService.Domain.Enitity
{
    public class Usuario : IEntidade<long>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
