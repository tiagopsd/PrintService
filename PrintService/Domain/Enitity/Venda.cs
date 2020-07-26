﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Venda : IEntidade<long>
    {
        public long Id { get; set; }
        public double Valor { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public virtual ICollection<PreVenda> PreVendas { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public long IdComprovantePagamento { get; set; }
       
        public IModeloImpressao ConverteModeloImpressao()
        {
            return (VendaModelo)this;
        }
    }
}
