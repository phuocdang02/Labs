namespace api.Configuration
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
