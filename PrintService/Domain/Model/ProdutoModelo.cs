using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class ProdutoModelo
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public static explicit operator ProdutoModelo(Produto produto)
            => produto == null ? null : new ProdutoModelo
            {
                Nome = produto.Nome,
                Valor = produto.Valor
            };
    }
}
