using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("teachers")]
    public class Teachers
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        [Required]
        [Column("fullname")]
        public required string FullName { get; set; }

        [Required]
        [Column("phone")]
        public required string Phone { get; set; }

        [Required]
        [Column("personal_email")]
        [EmailAddress]
        public required string PersonalEmailAddress { get; set; }

        [Required]
        [Column("business_email")]
        [EmailAddress]
        public required string BusinessEmailAddress { get; set; }

        public List<Schedules> Schedules { get; set; } = [];
    }
}
