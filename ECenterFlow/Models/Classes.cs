using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECenterFlow.Models
{
    [Table("classes")]
    public class Classes
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        [Required]
        [Column("room")]
        public required string Room { get; set; }

        [Required]
        [Column("shift")]
        public required string Shift { get; set; }

        [Required]
        [Column("sub_code")]
        public required string SubCode { get; set; }

        [Required]
        [Column("time")]
        public DateTime Time { get; set; }

        [Required]
        [Column("level")]
        public required string Level { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("number")]
        public required int Number { get; set; }

        [Required]
        [Column("start_date")]
        public required DateTime StartDate { get; set; }

        [Required]
        [Column("end_date")]
        public required DateTime EndDate { get; set;}

        [Required]
        [Column("term_1")]
        public required DateTime Term1 { get; set; }

        [Required]
        [Column("term_2")]
        public required DateTime Term2 { get; set;}

        [Required]
        [Column("final")]
        public required DateTime Final { get; set; }

        [Required]
        [Column("course")]
        public required string Course { get; set; }

        [Column("note")]
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
        [Column("training_mamangement_specialist")]
        public required string TrainingManagementSpecialist { get; set; }

    }
}
