using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("schedules")]
    public class Schedules
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        [Column("teacher")]
        public Guid TeacherId { get; set; }

        [Column("class")]
        public string ClassName { get; set; }

        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        public Teachers Teachers { get; set; }
    }
}
