﻿using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using System;

namespace PrintService.Domain.Model
{
    public class RingGameModelo : IModeloImpressao
    {
        public SituacaoVenda Situacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public ClienteModelo Cliente { get; set; }

        public static explicit operator RingGameModelo(CashGame cashGame) => 
            cashGame == null ? null : new RingGameModelo
            {
                DataCadastro = cashGame.DataCadastro,
                Cliente = (ClienteModelo)cashGame.Cliente,
                Situacao = cashGame.Situacao,
                Valor = cashGame.Valor
            };
    }
}
