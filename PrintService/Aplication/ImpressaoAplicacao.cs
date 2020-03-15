using Microsoft.Extensions.DependencyInjection;
using PrintService.Domain;
using PrintService.Domain.Enum;
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
        private IRepository _repository;
        private IBarAplicacao _barAplicacao;
        private IRingGameAplicacao _ringGameAplicacao;
        private ITorneioAplicacao _torneioAplicacao;
        private IPagamentoAplicacao _pagamentoAplicacao;
        private IComprovanteAplicacao _comprovanteAplicacao;

        public ImpressaoAplicacao(IRepository repository, IBarAplicacao barAplicacao, IRingGameAplicacao ringGameAplicacao,
            ITorneioAplicacao torneioAplicacao, IPagamentoAplicacao pagamentoAplicacao, IComprovanteAplicacao comprovanteAplicacao)
        {
            _repository = repository;
            _barAplicacao = barAplicacao;
            _ringGameAplicacao = ringGameAplicacao;
            _torneioAplicacao = torneioAplicacao;
            _pagamentoAplicacao = pagamentoAplicacao;
            _comprovanteAplicacao = comprovanteAplicacao;
        }

        public void Processar()
        {
            var impressoes = ObterImpressaoPendente();
            impressoes.ForEach(d => RealizaImpressao(d.TipoImpressao, d));
        }

        public void RealizaImpressao(TipoImpressao tipoImpressao, Impressao impressao)
        {
            switch (tipoImpressao)
            {
                case TipoImpressao.Bar:
                    _barAplicacao.Imprimir(impressao);
                    break;
                case TipoImpressao.RingGame:
                    _ringGameAplicacao.Imprimir(impressao);
                    break;
                case TipoImpressao.Torneio:
                    _torneioAplicacao.Imprimir(impressao);
                    break;
                case TipoImpressao.Pagamento:
                    _pagamentoAplicacao.Imprimir(impressao);
                    break;
                case TipoImpressao.Comprovante:
                    _comprovanteAplicacao.Imprimir(impressao);
                    break;
            }
        }

        private List<Impressao> ObterImpressaoPendente()
        {
            return _repository.ToList<Impressao>(d => d.SituacaoImpressao != SituacaoImpressao.Impresso);
        }
    }
}
