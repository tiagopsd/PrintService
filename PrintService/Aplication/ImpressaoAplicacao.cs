using Microsoft.Extensions.Logging;
using PrintService.Domain;
using PrintService.Domain.Enitity;
using PrintService.Domain.Enum;
using PrintService.Domain.Interface;
using PrintService.Infra.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Processar()
        {
            var impressoes = await ObterImpressaoPendente();

            foreach (var impressao in impressoes)
                await RealizaImpressao(impressao);
        }

        public async Task RealizaImpressao(Impressao impressao)
        {
            switch (impressao.TipoImpressao)
            {
                case TipoImpressao.Venda:
                    {
                        var venda = await _repository.GetById<Venda>(impressao.IdObjetoImpressao);
                        await Imprimir(impressao, ImplementacaoImpressao.ImpressaoVenda, venda.ConverteModeloImpressao());
                    }
                    break;
                case TipoImpressao.CashGame:
                    {
                        var cashGame = await _repository.GetById<CashGame>(impressao.IdObjetoImpressao);
                        await Imprimir(impressao, ImplementacaoImpressao.ImpressaoCashGame, cashGame.ConverteModeloImpressao());
                    }
                    break;
                case TipoImpressao.TorneioCliente:
                    {
                        var torneioCliente = await _repository.GetById<TorneioCliente>(impressao.IdObjetoImpressao);
                        await Imprimir(impressao, ImplementacaoImpressao.ImpressaoTorneioCliente, torneioCliente.ConverteModeloImpressao());
                    }
                    break;
                case TipoImpressao.Comprovante:
                    {
                        var pagamento = await _repository.GetById<Pagamento>(impressao.IdObjetoImpressao);
                        await Imprimir(impressao, ImplementacaoImpressao.ImpressaoComprovante, pagamento.ConverteModeloImpressao());
                    }
                    break;
            }
        }

        private async Task<List<Impressao>> ObterImpressaoPendente()
        {
            return await _repository.ToList<Impressao>(d => d.SituacaoImpressao != SituacaoImpressao.Impresso);
        }

        private async Task Imprimir(Impressao impressao, ImplementacaoImpressao implementacao, IModeloImpressao modeloImpressao)
        {
            _logger.LogInformation($"Realizando impressão {impressao.TipoImpressao}");

            _impressoes.ElementAt(implementacao.Value())
                .Imprimir(modeloImpressao, impressao.NomeImpressora);

            _logger.LogInformation($"Impressão {impressao.TipoImpressao} realizada com sucesso!");

            impressao.SituacaoImpressao = SituacaoImpressao.Impresso;

            await _context.SaveChangesAsync();
        }
    }
}
