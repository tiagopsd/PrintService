using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoVenda : ImpressaoBase
    {
        private Venda _venda;
        public void Imprime(Venda venda, string nomeImpressora)
        {
            try
            {
                _venda = venda;
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
                ev.Graphics.DrawString($"{item.Produto.Nome}: {item.Produto.Valor.ToString("c2")} QTD: {item.Quantidade}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            ev.Graphics.DrawString($"Situação: {_venda.Situacao.ToString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Valor: {_venda.Valor.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;
        }
    }
}
