using PrintService.Domain;
using PrintService.Domain.Interface;
using PrintService.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintService.Aplication
{
    public class ImpressaoAplicacao : IImpressaoAplicacao
    {
        readonly IContext _contexto;
        public ImpressaoAplicacao(IContext context)
        {
            _contexto = context;
        }

        public void Imprimir()
        {
            var teste = _contexto.Set<Impressao>().Where(d => d.Id > 0).ToList();
        }
    }
}
