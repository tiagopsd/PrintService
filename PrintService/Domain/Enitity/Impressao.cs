using PrintService.Domain.Enum;
using PrintService.Domain.Interface;

namespace PrintService.Domain
{
    public class Impressao : IEntidade<long>
    {
        public long Id { get; set; }
        public string NomeImpressora { get; set; }
        public TipoImpressao TipoImpressao { get; set; }
        public long IdObjetoImpressao { get; set; }
        public SituacaoImpressao SituacaoImpressao { get; set; }
    }
}
