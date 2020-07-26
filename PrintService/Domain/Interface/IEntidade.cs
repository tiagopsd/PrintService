using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Interface
{
    public interface IEntidade<T> : IEntidade
    {
        T Id { get; set; }
        IModeloImpressao ConverteModeloImpressao();
    }

    public interface IEntidade
    {
    }
}
