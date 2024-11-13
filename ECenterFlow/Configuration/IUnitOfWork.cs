namespace ECenterFlow.Configuration
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
