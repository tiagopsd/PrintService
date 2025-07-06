using Microsoft.Extensions.Logging;
using PrintService.Domain.Interface;
using System;
using System.Drawing.Printing;

namespace PrintService.Infra.Impressora
{
    public abstract class ImpressaoBase : IImpressao
    {
        protected readonly ILogger<Worker> _logger;
        public ImpressaoBase(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public const string Epson = "EPSON TM-T88V Receipt";
        public const string CS = "CIS PR 3000";

        public void ImprimeUmaVez(PrintPageEventHandler evento, string nomeImpressora)
        {
            var printDoc = new PrintDocument
            {
                DocumentName = "Cupom"
            };
            printDoc.PrintPage += evento;

            if (nomeImpressora.ToLower() == "epson")
                printDoc.PrinterSettings.PrinterName = Epson;
            else if (nomeImpressora.ToLower() == "cis")
                printDoc.PrinterSettings.PrinterName = CS;
            else if (!printDoc.PrinterSettings.IsValid)
                throw new Exception("Não foi possível localizar a impressora");

            printDoc.Print();
        }

        public abstract void Imprimir(IModeloImpressao modeloImpressao, string impressora);
    }
}
