using PrintService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Utils
{
    public static class Extension
    {
        public static bool TemValor(this string valor) => !string.IsNullOrEmpty(valor);
        public static int Valor(this ImplementacaoImpressao implementacaoImpressao) => (int)implementacaoImpressao;
    }
}
