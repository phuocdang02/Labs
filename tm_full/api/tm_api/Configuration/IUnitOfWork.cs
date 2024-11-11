namespace tm_api.Configuration
{
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Asynchronously completes pending database changes.
        /// </summary>
        Task CompleteAsync();
    }
}
