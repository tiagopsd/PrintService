using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PrintService.Domain.Enum
{
    public enum ImplementacaoImpressao : int
    {
        ImpressaoCashGame = 0,
        ImpressaoComprovante = 1,
        ImpressaoTorneioCliente = 2,
        ImpressaoVenda = 3
    }
}
