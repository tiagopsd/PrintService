using PrintService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class CashGameModelo
    {
        public SituacaoVenda Situacao { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeCliente { get; set; }
    }
}
