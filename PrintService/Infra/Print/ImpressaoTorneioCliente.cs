using Microsoft.Extensions.Logging;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using PrintService.Infra.Utils;
using System;
using System.Drawing;
using System.Drawing.Printing;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoTorneioCliente : ImpressaoBase
    {
        private TorneioClienteModelo _torneioCliente;
        public ImpressaoTorneioCliente(ILogger<Worker> logger) : base(logger)
        {
        }

        public override void Imprimir(IModeloImpressao torneioCliente, string nomeImpressora)
        {
            try
            {
                _torneioCliente = (TorneioClienteModelo)torneioCliente;
                ImprimeUmaVez(Evento, nomeImpressora);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Erro ao realizar impressão do Torneio Cliente! " +
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

            ev.Graphics.DrawString($"Cliente: {_torneioCliente.Cliente.Nome}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
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

            if (_torneioCliente.BuyIn > 0)
            {
                ev.Graphics.DrawString($"Buy-In: {_torneioCliente.Torneio.BuyIn:c2} QTD: {_torneioCliente.BuyIn}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.BuyDouble > 0)
            {
                ev.Graphics.DrawString($"Buy-Double: {_torneioCliente.Torneio.BuyDouble:c2} QTD: {_torneioCliente.BuyDouble}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.ReBuy > 0)
            {
                ev.Graphics.DrawString($"Re-Buy: {_torneioCliente.Torneio.ReBuy:c2} QTD: {_torneioCliente.ReBuy}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.Addon > 0)
            {
                ev.Graphics.DrawString($"Addon: {_torneioCliente.Torneio.Addon:c2} QTD: {_torneioCliente.Addon}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.JackPot > 0)
            {
                ev.Graphics.DrawString($"JackPot: {_torneioCliente.Torneio.JackPot:c2} QTD: {_torneioCliente.JackPot}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.TaxaAdm > 0)
            {
                ev.Graphics.DrawString($"TaxaAdm: {_torneioCliente.Torneio.TaxaAdm:c2} QTD: {_torneioCliente.TaxaAdm}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            if (_torneioCliente.BonusBeneficente.HasValue())
            {
                var bonus = _torneioCliente.BonusBeneficente.Contains("5") ? $"R$ {_torneioCliente.BonusBeneficente}" : _torneioCliente.BonusBeneficente;
                ev.Graphics.DrawString($"BonusBeneficente: {bonus}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }

            ev.Graphics.DrawString($"Situação: {_torneioCliente.Situacao}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Total: {_torneioCliente.ValorTotal:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            if (_torneioCliente.ValorPago > 0)
            {
                ev.Graphics.DrawString($"Valor Pago: {_torneioCliente.ValorPago:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString($"Valor à Pagar: {(_torneioCliente.ValorTotal - _torneioCliente.ValorPago):c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;
            }
        }
    }
}
