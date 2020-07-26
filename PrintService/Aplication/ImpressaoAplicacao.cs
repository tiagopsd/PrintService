using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrintService.Domain;
using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using PrintService.Infra;
using PrintService.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintService.Aplication
{
    public class ImpressaoAplicacao : AplicacaoBase, IImpressaoAplicacao
    {
        public ImpressaoAplicacao(
            IRepository repository,
            IEnumerable<IImpressao> impressoes,
            IContext context,
            ILogger<Worker> logger)
            : base(repository, impressoes, context, logger)
        {
        }

        public void Processar()
        {
            var impressoes = ObterImpressaoPendente();

            impressoes.ForEach(d =>
            {
                RealizaImpressao(d);
            });
        }

        public void RealizaImpressao(Impressao impressao)
        {
            switch (impressao.TipoImpressao)
            {
                case TipoImpressao.Venda:
                    {
                        var modeloImpressao = _repository.GetById<Venda>(impressao.IdObjetoImpressao).ConverteModeloImpressao();
                        Imprimir(impressao, ImplementacaoImpressao.ImpressaoVenda, modeloImpressao);
                    }
                    break;
                case TipoImpressao.CashGame:
                    {
                        var modeloImpressao = _repository.GetById<CashGame>(impressao.IdObjetoImpressao).ConverteModeloImpressao();
                        Imprimir(impressao, ImplementacaoImpressao.ImpressaoCashGame, modeloImpressao);
                    }
                    break;
                case TipoImpressao.TorneioCliente:
                    {
                        var modeloImpressao = _repository.GetById<TorneioCliente>(impressao.IdObjetoImpressao).ConverteModeloImpressao();
                        Imprimir(impressao, ImplementacaoImpressao.ImpressaoTorneioCliente, modeloImpressao);
                    }
                    break;
                case TipoImpressao.Comprovante:
                    {
                        var modeloImpressao = _repository.GetById<Pagamento>(impressao.IdObjetoImpressao).ConverteModeloImpressao();
                        Imprimir(impressao, ImplementacaoImpressao.ImpressaoComprovante, modeloImpressao);
                    }
                    break;
            }
        }

        private List<Impressao> ObterImpressaoPendente()
        {
            return _repository.ToList<Impressao>(d => d.SituacaoImpressao != SituacaoImpressao.Impresso);
        }

        private void Imprimir(Impressao impressao, ImplementacaoImpressao implementacao, IModeloImpressao modeloImpressao)
        {
            _logger.LogInformation($"Realizando impressão {impressao.TipoImpressao}");
            _impressoes.ElementAt(implementacao.Valor()).Imprimir(modeloImpressao, impressao.NomeImpressora);
            _logger.LogInformation($"Impressão {impressao.TipoImpressao} realizada com sucesso!");
            impressao.SituacaoImpressao = SituacaoImpressao.Impresso;
            _context.SaveChanges();
        }
    }
}
