using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrintService.Domain.Enum
{
    public enum TipoFinalizador : short
    {
        Conta = 0,
        Dinheiro = 1,
        [Description("Cartão de Débito")]
        Debito = 2,
        [Description("Cartão de Crédito")]
        Credito = 3,
        Cheque = 4,
        Cortesia = 5,
        Nenhum = 6,
        Saldo = 7,
        EmAberto = 10
    }
}
