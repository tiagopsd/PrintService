using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoTorneioCliente : ImpressaoBase
    {
        private TorneioCliente _torneioCliente;
        public void Imprime(TorneioCliente torneioCliente, string nomeImpressora)
        {
            try
            {
                _torneioCliente = torneioCliente;
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

            ev.Graphics.DrawString($"Cliente: {_torneioCliente.NomeCliente}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Data: {_torneioCliente.DataCadastro.ToShortDateString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Hora: {_torneioCliente.DataCadastro.ToShortTimeString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"{_torneioCliente.Torneio.Nome}", TorneioFonte, Brushes.Black, 65, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            if (_torneioCliente.BuyIn.HasValue)
            {
                ev.Graphics.DrawString($"Buy-In: {_torneioCliente.Torneio.BuyIn.Value.ToString("c2")} QTD: {_torneioCliente.BuyIn}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.BuyDouble.HasValue)
            {
                ev.Graphics.DrawString($"Buy-Double: {_torneioCliente.Torneio.BuyDouble.Value.ToString("c2")} QTD: {_torneioCliente.BuyDouble}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.ReBuy.HasValue)
            {
                ev.Graphics.DrawString($"Re-Buy: {_torneioCliente.Torneio.ReBuy.Value.ToString("c2")} QTD: {_torneioCliente.ReBuy}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.Addon.HasValue)
            {
                ev.Graphics.DrawString($"Addon: {_torneioCliente.Torneio.Addon.Value.ToString("c2")} QTD: {_torneioCliente.Addon}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.JackPot.HasValue)
            {
                ev.Graphics.DrawString($"JackPot: {_torneioCliente.Torneio.JackPot.Value.ToString("c2")} QTD: {_torneioCliente.JackPot}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.TaxaAdm.HasValue)
            {
                ev.Graphics.DrawString($"TaxaAdm: {_torneioCliente.Torneio.TaxaAdm.Value.ToString("c2")} QTD: {_torneioCliente.TaxaAdm}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.BonusBeneficente.TemValor())
            {
                var bonus = _torneioCliente.BonusBeneficente.Contains("5") ? $"R$ {_torneioCliente.BonusBeneficente}" : _torneioCliente.BonusBeneficente;
                ev.Graphics.DrawString($"BonusBeneficente: {bonus}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            ev.Graphics.DrawString($"Situação: {_torneioCliente.Situacao.ToString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Total: {_torneioCliente.ValorTotal.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            if (_torneioCliente.ValorPago.HasValue && _torneioCliente.ValorPago > 0)
            {
                ev.Graphics.DrawString($"Valor Pago: {_torneioCliente.ValorPago.Value.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString($"Valor à Pagar: {(_torneioCliente.ValorTotal - _torneioCliente.ValorPago).Value.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }
        }
    }
}
