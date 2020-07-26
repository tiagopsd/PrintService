﻿using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Pagamento : IEntidade<long>
    {
        public long Id { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<CashGame> CashGames { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
        public virtual ICollection<TorneioCliente> TorneiosClientes { get; set; }
        public virtual ICollection<ParcelamentoPagamento> ParcelamentoPagamentos { get; set; }

        public IModeloImpressao ConverteModeloImpressao() => (ComprovanteModelo)this;
    }
}
