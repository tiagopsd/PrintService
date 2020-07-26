using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Model
{
    public class CashGameModelo : IModeloImpressao
    {
        public SituacaoVenda Situacao { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public ClienteModelo Cliente { get; set; }

        public static explicit operator CashGameModelo(CashGame cashGame) => 
            cashGame == null ? null : new CashGameModelo
            {
                DataCadastro = cashGame.DataCadastro,
                Cliente = (ClienteModelo)cashGame.Cliente,
                Situacao = cashGame.Situacao,
                Valor = cashGame.Valor
            };
    }
}
