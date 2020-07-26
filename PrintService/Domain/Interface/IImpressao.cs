using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Interface
{
    public interface IImpressao
    {
        void Imprimir(IModeloImpressao modeloImpressao, string impressora); 
    }
}
