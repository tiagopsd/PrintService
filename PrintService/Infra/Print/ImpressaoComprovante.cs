using Microsoft.Extensions.Logging;
using PrintService.Domain.Interface;
using PrintService.Domain.Model;
using PrintService.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoComprovante : ImpressaoBase
    {
        private ComprovanteModelo comprovanteModel;

        public ImpressaoComprovante(ILogger<Worker> logger) : base(logger)
        {
        }

        public override void Imprimir(IModeloImpressao comprovanteModel, string nomeImpressora)
        {
            try
            {
                this.comprovanteModel = (ComprovanteModelo)comprovanteModel;
                ImprimeUmaVez(EventoEpson, nomeImpressora);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Erro ao realizar impressão do Comprovante! " +
                    $"Impressora: {nomeImpressora}" +
                    $"StackTrace: {erro.GetBaseException().StackTrace} " +
                    $"erro: {erro.GetBaseException().Message}");
            }
        }

        private void EventoEpson(object sender, PrintPageEventArgs ev)
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

            ev.Graphics.DrawString($"Cliente: {comprovanteModel.Cliente.Nome}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Data: {comprovanteModel.Pagamento.Data.ToShortDateString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Hora: {comprovanteModel.Pagamento.Data.ToShortTimeString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("Pagamento", TorneioFonte, Brushes.Black, 65, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
            currentUsedHeight += size.Height;

            if (comprovanteModel.CashGames.Count() > 0)
            {
                ev.Graphics.DrawString("Ring Game", spaceFonte, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;

                foreach (var cash in comprovanteModel.CashGames)
                {
                    ev.Graphics.DrawString($"Data: {cash.DataCadastro.ToShortDateString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    ev.Graphics.DrawString($"Valor: {cash.Valor:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;
                }

                ev.Graphics.DrawString($"Total: {comprovanteModel.CashGames.Sum(d => d.Valor):c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                currentUsedHeight += size.Height;

            }

            if (comprovanteModel.Vendas.Count() > 0)
            {
                ev.Graphics.DrawString("Bar", spaceFonte, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;

                foreach (var venda in comprovanteModel.Vendas)
                {
                    ev.Graphics.DrawString($"Data Venda: {venda.DataVenda.ToShortDateString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    foreach (var preVenda in venda.PreVendas)
                    {
                        ev.Graphics.DrawString($"{preVenda.Produto.Nome}: {preVenda.Produto.Valor:c2} QTD: {preVenda.Quantidade}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    ev.Graphics.DrawString($"Total Venda: {venda.Valor:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
                if (comprovanteModel.Vendas.Count() > 1)
                {
                    ev.Graphics.DrawString($"Total Venda: {comprovanteModel.Vendas.Sum(d => d.Valor):c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
            }

            if (comprovanteModel.TorneiosCliente.Count() > 0)
            {
                foreach (var torneioCliente in comprovanteModel.TorneiosCliente)
                {
                    ev.Graphics.DrawString($"{ torneioCliente.Torneio.Nome} - Data: {torneioCliente.DataCadastro.ToShortDateString()}", spaceFonte, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    if (torneioCliente.BuyDouble > 0)
                    {
                        ev.Graphics.DrawString($"Buy-Double: {torneioCliente.Torneio.BuyDouble:c2} QTD: {torneioCliente.BuyDouble}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    else if (torneioCliente.BuyIn > 0)
                    {
                        ev.Graphics.DrawString($"Buy-In: {torneioCliente.Torneio.BuyIn:c2} QTD: {torneioCliente.BuyIn}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneioCliente.ReBuy > 0)
                    {
                        ev.Graphics.DrawString($"Re-Buy: {torneioCliente.Torneio.ReBuy:c2} QTD: {torneioCliente.ReBuy}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneioCliente.Addon > 0)
                    {
                        ev.Graphics.DrawString($"Addon: {torneioCliente.Torneio.Addon:c2} QTD: {torneioCliente.Addon}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneioCliente.JackPot > 0)
                    {
                        ev.Graphics.DrawString($"JackPot: {torneioCliente.Torneio.JackPot:c2} QTD: {torneioCliente.JackPot}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneioCliente.TaxaAdm > 0)
                    {
                        ev.Graphics.DrawString($"Taxa Adm: {torneioCliente.Torneio.TaxaAdm:c2} QTD: {torneioCliente.TaxaAdm}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneioCliente.BonusBeneficente.TemValor())
                    {
                        var bonusFormato = torneioCliente.BonusBeneficente.Contains("5") ? "R$ " + torneioCliente.BonusBeneficente : "Alimento";
                        ev.Graphics.DrawString($"Bônus Beneficente: {bonusFormato}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneioCliente.Jantar > 0)
                    {
                        ev.Graphics.DrawString($"Jantar: {torneioCliente.Torneio.Jantar:c2} QTD: {torneioCliente.Jantar}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    ev.Graphics.DrawString($"Total: {torneioCliente.ValorTotal:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
            }

            if (comprovanteModel.ParcelamentoPagamentos.Any())
            {
                ev.Graphics.DrawString($"Parcelamento", spaceFonte, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;

                foreach (var parcela in comprovanteModel.ParcelamentoPagamentos)
                {
                    ev.Graphics.DrawString($"Data: {parcela.DataPagamento.ToShortDateString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    ev.Graphics.DrawString($"Valor parcela: {parcela.ValorPago:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    ev.Graphics.DrawString($"Finalizador: {parcela.TipoFinalizador}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
            }


            ev.Graphics.DrawString($"Total Pago: {comprovanteModel.Pagamento.ValorTotal:c2}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;
        }
    }
}
