using PrintService.Domain.Enitity;
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
        private CashGameModelo cash;
        public void Imprime(CashGameModelo cashGame, string nomeImpressora)
        {
            try
            {
                cash = cashGame;
                ImprimeUmaVez(Evento, nomeImpressora);
            }
            catch
            {
            }

        }

        private void Evento(object sender, PrintPageEventArgs ev)
        {
            System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 22f, FontStyle.Bold);
            System.Drawing.Font spaceTitleFonte = new System.Drawing.Font("Segoe UI", 25f, FontStyle.Bold);
            System.Drawing.Font spaceFonte = new System.Drawing.Font("Segoe UI", 10f, FontStyle.Bold);
            System.Drawing.Font spaceDataHoraFonte = new System.Drawing.Font("Segoe UI", 18f, FontStyle.Bold);
            System.Drawing.Font TorneioFonte = new System.Drawing.Font("Segoe UI", 16f, FontStyle.Bold);


            System.Drawing.Font pdvFont = new System.Drawing.Font("Segoe UI", 14f, FontStyle.Regular);
            System.Drawing.Font obsFont = new System.Drawing.Font("Segoe UI", 7f, FontStyle.Regular);

            SizeF size = new SizeF();
            float currentUsedHeight = 10f;

            ev.Graphics.DrawString("Boteco do Poker", titleFont, Brushes.DarkBlue, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceTitleFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Cliente: {cash.NomeCliente}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Data: {cash.DataCadastro.ToShortDateString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Hora: {cash.DataCadastro.ToShortTimeString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Ring Game", TorneioFonte, Brushes.Black, 65, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Valor: {cash.Valor.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Situação: {cash.Situacao.ToString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;
        }
    }
}
