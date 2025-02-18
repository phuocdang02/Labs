using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("students")]
    public class Students
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        [Required]
        [Column("consultant")]
        public required string Consultant { get; set; }

        [Required]
        [Column("academic_cordinator")]
        public required string AcademicCordinator { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Required]
        [Column("student_code")]
        public required string StudentCode { get; set; }

        [Required]
        [Column("fullname")]
        public required string FullName { get; set; }

        [Required]
        [Column("phone_1")]
        public required string Phone1 { get; set; }

        [Column("phone_2")]
        public string? Phone2 { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("school")]
        public string? School { get; set; }

        [Required]
        [Column("dob")]
        public required DateTime Dob { get; set; }

        [Required]
        [Column("gender")]
        public Gender Gender { get; set; }

        [Required]
        [Column("note")]
        public string? Note { get; set; }

        [Required]
        [Column("teacher_name")]
        public string? TeacherName { get; set; }

        [Required]
        [Column("course_number")]
        public int CourseNumber { get; set; }

        [Column("trial_date")]
        public DateTime? TrialDate { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }
    }
}
