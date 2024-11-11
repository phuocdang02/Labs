using System.ComponentModel.DataAnnotations;

namespace tm_api.Models
{
    public class Branch
    {
        [Key]
        public Guid BranchID { get; set; }
        public required string BranchName { get; set; }
        public int TotalClasses { get; set; }
        public int TotalStudents { get; set; }
    }
}
