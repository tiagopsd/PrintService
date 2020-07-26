using Microsoft.Extensions.Logging;
using PrintService.Domain.Enitity;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoCashGame : ImpressaoBase
    {
        private CashGameModelo _cash;

        public ImpressaoCashGame(ILogger<Worker> logger) : base(logger)
        {
        }

        public override void Imprimir(IModeloImpressao cashGame, string nomeImpressora)
        {
            try
            {
                _cash = (CashGameModelo)cashGame;
                ImprimeUmaVez(Evento, nomeImpressora);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Erro ao realizar impressão do Ring Game! " +
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

            ev.Graphics.DrawString($"Cliente: {_cash.Cliente.Nome}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Data: {_cash.DataCadastro.ToShortDateString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Hora: {_cash.DataCadastro.ToShortTimeString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Ring Game", TorneioFonte, Brushes.Black, 65, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Valor: {_cash.Valor:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Situação: {_cash.Situacao}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;
        }
    }
}
