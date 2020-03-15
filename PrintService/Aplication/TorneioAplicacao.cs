using PrintService.Domain;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Aplication
{
    public class TorneioAplicacao : ITorneioAplicacao
    {
        private IRepository _repository;
        public TorneioAplicacao(IRepository repository)
        {
            _repository = repository;
        }

        public void Imprimir(Impressao impressao)
        {

        }
    }
}
