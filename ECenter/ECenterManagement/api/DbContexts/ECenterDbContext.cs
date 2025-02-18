using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DbContexts
{
    public class ECenterDbContext : DbContext
    {
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Levels> Levels { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ECenterFlowDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContext options for configuring the database context.</param>
        public ECenterDbContext(DbContextOptions<ECenterDbContext> options) : base(options) { }
    }
}
