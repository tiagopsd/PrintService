using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain
{
    public class Impressao
    {
        public long Id { get; set; }
        public string NomeImpressora { get; set; }
        public TipoImpressao TipoImpressao { get; set; }
        public long IdObjetoImpressao { get; set; }
    }
}
