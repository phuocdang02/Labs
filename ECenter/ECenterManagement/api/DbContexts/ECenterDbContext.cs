using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.DbContexts;

/// <summary>
/// Database context for the application
/// </summary>
public class ECenterDbContext : IdentityDbContext<ApplicationUser>
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
    /// Gets or sets the application user
    /// </summary>
    //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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

        base.OnModelCreating(modelBuilder);

        // Customize Identity table names if needed
        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
    }
}
