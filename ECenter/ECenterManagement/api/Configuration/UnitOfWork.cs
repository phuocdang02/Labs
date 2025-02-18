using api.DbContexts;

namespace api.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECenterDbContext _dbContext;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context for unit of work</param>
        /// <param name="loggerFactory">The logger factory for creating a logger</param>
        public UnitOfWork(ECenterDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");
        }

        /// <summary>
        /// Asynchronously completes pending database changes
        /// </summary>
        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disposes of the database context when the unit of work is no longer needed
        /// </summary>
        public void Dispose() => _dbContext.Dispose();
    }
}
