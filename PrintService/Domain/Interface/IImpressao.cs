namespace PrintService.Domain.Interface
{
    public interface IImpressao
    {
        void Imprimir(IModeloImpressao modeloImpressao, string impressora); 
    }
}
