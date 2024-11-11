using tm_api.Data;

namespace tm_api.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EnglishCenterManagementDBContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context for unit of work.</param>
        /// <param name="loggerFactory">The logger factory for creating a logger.</param>
        public UnitOfWork(EnglishCenterManagementDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }
        /// <summary>
        /// Asynchronously completes pending database changes.
        /// </summary>
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Disposes of the database context when the unit of work is no longer needed.
        /// </summary>
        public void Dispose() => _context.Dispose();
    }
}
