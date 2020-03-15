using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Pagamento
    {
        public long Id { get; set; }
        public double ValorTotal { get; set; }
        public double ValorAberto { get; set; }
        public DateTime Data { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
