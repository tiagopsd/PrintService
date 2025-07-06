using PrintService.Domain.Enum;

namespace PrintService.Infra.Utils
{
    public static class Extension
    {
        public static bool HasValue(this string valor) => !string.IsNullOrEmpty(valor);
        public static short Value(this ImplementacaoImpressao implementacaoImpressao) => (short)implementacaoImpressao;
    }
}
