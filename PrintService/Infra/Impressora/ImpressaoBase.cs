using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;

namespace PrintService.Infra.Impressora
{
    public class ImpressaoBase
    {
        public const string Epson = "EPSON TM-T88V Receipt";
        public const string CS = "CIS PR 3000";

        public void ImprimeUmaVez(PrintPageEventHandler evento, string nomeImpressora)
        {
            PrintDocument printDoc = new PrintDocument
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
    }
}
