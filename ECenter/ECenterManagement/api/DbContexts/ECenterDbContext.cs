using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DbContexts;

/// <summary>
/// Database context for the application
/// </summary>
public class ECenterDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ECenterDbContext"/> class.
    /// </summary>
    /// <param name="options">The DbContext options for configuring the database context.</param>
    public ECenterDbContext(DbContextOptions<ECenterDbContext> options) : base(options) { }

    /// <summary>
    /// Gets or sets the teacher table
    /// </summary>
    public DbSet<Teacher> Teachers { get; set; }
    //public DbSet<Classes> Classes { get; set; }
    //public DbSet<Students> Students { get; set; }
    //public DbSet<Rooms> Rooms { get; set; }
    //public DbSet<Courses> Courses { get; set; }
    //public DbSet<Levels> Levels { get; set; }

    /// <summary>
    /// Gets or sets the schedule table
    /// </summary>
    public DbSet<Schedule> Schedules { get; set; }

    /// <summary>
    /// Configures the model relationships
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasMany(x => x.Schedules)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId);
    }
}
