using PrintService.Domain.Enitity;

namespace PrintService.Domain.Model
{
    public class ClienteModelo
    {
        public string Nome { get; set; }

        public static explicit operator ClienteModelo(Cliente cliente) 
            => cliente == null ? null : new ClienteModelo
            {
                Nome = cliente.Nome
            };
    }
}
