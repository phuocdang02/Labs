using Microsoft.EntityFrameworkCore;

namespace ECenterFlow.DbContexts
{
    public class ECenterFlowDbContext: DbContext
    {
        public ECenterFlowDbContext(DbContextOptions<ECenterFlowDbContext> options): base(options) { }
    }
}
