using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Classes
    {
        [Key]
        [Required]
        public required Guid Id { get; set; }

        [Required]
        public required string Room { get; set; }

        [Required]
        public required string Shift { get; set; }

        [Required]
        public required string SubCode { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public required string Level { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int Number { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }

        [Required]
        public required DateTime Term1 { get; set; }

        [Required]
        public required DateTime Term2 { get; set; }

        [Required]
        public required DateTime Final { get; set; }

        [Required]
        public required string Course { get; set; }
        public string? Note { get; set; }

        //[Required]
        //[Column("teacher_id")]
        //public required Guid TeacherId { get; set; }

        //[Required]
        //[Column("teacher_name")]
        //public required string TeacherName { get; set; }

        //[Required]
        //[Column("teacher_phone")]
        //[Phone]
        //public required string TeacherPhone { get; set; }

        //[Required]
        //[Column("teacher_email")]
        //[EmailAddress]
        //public required string TeacherEMail { get; set; }

        [Required]
        public required string TrainingManagementSpecialist { get; set; }

    }
}
