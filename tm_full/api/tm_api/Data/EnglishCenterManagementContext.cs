using Microsoft.EntityFrameworkCore;
using tm_api.Models;

namespace tm_api.Data
{
    public class EnglishCenterManagementDBContext: DbContext
    {
        public EnglishCenterManagementDBContext(DbContextOptions<EnglishCenterManagementDBContext> options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        //public DbSet<Program> Programs { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Class> Classes { get; set; }
        //public DbSet<ClassAssignment> ClassAssignments { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<ClassDetail> ClassDetails { get; set; }
        //public DbSet<ContactDetail> ContactDetails { get; set; }
        //public DbSet<Attendance> Attendances { get; set; }
    }
}
