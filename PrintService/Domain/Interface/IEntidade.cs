namespace PrintService.Domain.Interface
{
    public interface IEntidade<T> : IEntidade
    {
        T Id { get; set; }
    }

    public interface IEntidade
    {
    }
}
