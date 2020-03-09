using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain
{
    public enum TipoImpressao : short
    {
        Bar = 0,
        RingGame = 1,
        Torneio = 2,
        Pagamento = 3,
        Comprovante = 4
    }
}
