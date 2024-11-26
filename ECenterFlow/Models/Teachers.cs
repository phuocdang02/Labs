using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECenterFlow.Models
{
    [Table("teachers")]
    public class Teachers
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        //[Required]
        //[Column("teacher_id")]
        //public required string TeacherId { get; set; }

        [Required]
        [Column("fullname")]
        public required string FullName { get; set; }

        [Required]
        [Column("phone")]
        public required string Phone { get; set; }

        [Required]
        [Column("email")]
        [EmailAddress]
        public required string EmailAddress { get; set; }
    }
}
