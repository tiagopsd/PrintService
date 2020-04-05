using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Utils
{
    public static class Extension
    {
        public static bool TemValor(this string valor)
        {
            return !string.IsNullOrEmpty(valor);
        }

    }
}
