using PrintService.Domain.Model;
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
        public void Imprime(ComprovanteModelo comprovanteModel, string nomeImpressora)
        {
            try
            {
                this.comprovanteModel = comprovanteModel;
                ImprimeUmaVez(EventoEpson, nomeImpressora);
            }
            catch
            {
            }
        }

        private void EventoEpson(object sender, PrintPageEventArgs ev)
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

            ev.Graphics.DrawString($"Cliente: {comprovanteModel.NomeCliente}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Data: {comprovanteModel.DataPagamento.ToShortDateString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString($"Hora: {comprovanteModel.DataPagamento.ToShortTimeString()}", pdvFont, Brushes.Black, 10, currentUsedHeight, new StringFormat());
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

                    ev.Graphics.DrawString($"Valor: {cash.Valor.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;
                }

                ev.Graphics.DrawString($"Total: {comprovanteModel.CashGames.Sum(d => d.Valor).ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
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
                        ev.Graphics.DrawString($"{preVenda.NomeProduto}: {preVenda.ValorProduto.ToString("c2")} QTD: {preVenda.Quantidade}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    ev.Graphics.DrawString($"Total Venda: {venda.Valor.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
                if (comprovanteModel.Vendas.Count() > 1)
                {
                    ev.Graphics.DrawString($"Total Venda: {comprovanteModel.Vendas.Sum(d => d.Valor).ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
            }

            if (comprovanteModel.TorneiosCliente.Count() > 0)
            {
                foreach (var torneio in comprovanteModel.TorneiosCliente)
                {
                    ev.Graphics.DrawString($"{ torneio.Torneio.Nome} - Data: {torneio.DataCadastro.ToShortDateString()}", spaceFonte, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    if (torneio.BuyDouble.HasValue && torneio.BuyDouble > 0)
                    {
                        ev.Graphics.DrawString($"Buy-Double: {torneio.Torneio.BuyDouble.Value.ToString("c2")} QTD: {torneio.BuyDouble}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    else if (torneio.BuyIn.HasValue && torneio.BuyIn > 0)
                    {
                        ev.Graphics.DrawString($"Buy-In: {torneio.Torneio.BuyIn.Value.ToString("c2")} QTD: {torneio.BuyIn}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneio.ReBuy.HasValue && torneio.ReBuy > 0)
                    {
                        ev.Graphics.DrawString($"Re-Buy: {torneio.Torneio.ReBuy.Value.ToString("c2")} QTD: {torneio.ReBuy}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneio.Addon.HasValue && torneio.Addon > 0)
                    {
                        ev.Graphics.DrawString($"Addon: {torneio.Torneio.Addon.Value.ToString("c2")} QTD: {torneio.Addon}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneio.JackPot.HasValue && torneio.JackPot > 0)
                    {
                        ev.Graphics.DrawString($"JackPot: {torneio.Torneio.JackPot.Value.ToString("c2")} QTD: {torneio.JackPot}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneio.TaxaAdm.HasValue && torneio.TaxaAdm > 0)
                    {
                        ev.Graphics.DrawString($"Taxa Adm: {torneio.Torneio.TaxaAdm.Value.ToString("c2")} QTD: {torneio.TaxaAdm}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneio.BonusBeneficente.TemValor())
                    {
                        var bonusFormato = torneio.BonusBeneficente.Contains("5") ? "R$ " + torneio.BonusBeneficente : "Alimento";
                        ev.Graphics.DrawString($"Bônus Beneficente: {bonusFormato}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    if (torneio.Jantar.HasValue && torneio.Jantar > 0)
                    {
                        ev.Graphics.DrawString($"Jantar: {torneio.Torneio.Jantar.Value.ToString("c2")} QTD: {torneio.Jantar}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                        size = ev.Graphics.MeasureString("X", spaceFonte);
                        currentUsedHeight += size.Height;
                    }

                    ev.Graphics.DrawString($"Total: {torneio.ValorTotal.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
            }

            if (comprovanteModel.ParcelamentoPagamentos.Count() > 0)
            {
                ev.Graphics.DrawString($"Parcelamento", spaceFonte, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("X", spaceFonte);
                currentUsedHeight += size.Height;

                foreach (var parcela in comprovanteModel.ParcelamentoPagamentos)
                {
                    ev.Graphics.DrawString($"Data: {parcela.DataPagamento.ToShortDateString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    ev.Graphics.DrawString($"Valor parcela: {parcela.ValorPago.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceFonte);
                    currentUsedHeight += size.Height;

                    ev.Graphics.DrawString($"Finalizador: {parcela.TipoFinalizador.ToString()}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString("X", spaceDataHoraFonte);
                    currentUsedHeight += size.Height;
                }
            }


            ev.Graphics.DrawString($"Total Pago: {comprovanteModel.Pagamento.ValorTotal.ToString("c2")}", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("X", spaceFonte);
            currentUsedHeight += size.Height;
        }
    }
}
