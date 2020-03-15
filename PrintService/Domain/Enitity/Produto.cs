using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public double ValorCompra { get; set; }
        public short QtdEstoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
