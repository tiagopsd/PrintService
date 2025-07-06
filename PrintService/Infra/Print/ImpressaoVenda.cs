using Microsoft.Extensions.Logging;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;
using System.Drawing;
using System.Drawing.Printing;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoVenda : ImpressaoBase
    {
        private VendaModelo _venda;
        public ImpressaoVenda(ILogger<Worker> logger) : base(logger)
        {
        }

        public override void Imprimir(IModeloImpressao venda, string nomeImpressora)
        {
            try
            {
                _venda = (VendaModelo)venda;
                ImprimeUmaVez(Evento, nomeImpressora);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Erro ao realizar impressão da Venda! " +
                    $"Impressora: {nomeImpressora}" +
                    $"StackTrace: {erro.GetBaseException().StackTrace} " +
                    $"erro: {erro.GetBaseException().Message}");
            }
        }

        private void Evento(object sender, PrintPageEventArgs ev)
        {
            Font titleFont = new Font("Segoe UI", 22f, FontStyle.Bold);
            Font spaceTitleFonte = new Font("Segoe UI", 25f, FontStyle.Bold);
            Font spaceFonte = new Font("Segoe UI", 10f, FontStyle.Bold);
            Font spaceDataHoraFonte = new Font("Segoe UI", 18f, FontStyle.Bold);
            Font TorneioFonte = new Font("Segoe UI", 16f, FontStyle.Bold);


            Font pdvFont = new Font("Segoe UI", 14f, FontStyle.Regular);
            Font obsFont = new Font("Segoe UI", 7f, FontStyle.Regular);

            SizeF size = new SizeF();
            float currentUsedHeight = 10f;

            ev.Graphics.DrawString("Boteco do Poker", titleFont, Brushes.DarkBlue, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceTitleFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Cliente: {_venda.Cliente.Nome}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Data: {_venda.DataVenda.ToShortDateString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Hora: {_venda.DataVenda.ToShortTimeString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Bar", TorneioFonte, Brushes.Black, 65, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            foreach (var item in _venda.PreVendas)
            {
                ev.Graphics.DrawString($"{item.Produto.Nome}: {item.Produto.Valor:c2} QTD: {item.Quantidade}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            ev.Graphics.DrawString($"Situação: {_venda.Situacao}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Valor: {_venda.Valor:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;
        }
    }
}
