using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

/// <summary>
/// Represents a teacher in the system
/// </summary>
[Table("teachers")]
public class Teacher
{
    /// <summary>
    /// Gets or sets the unique identifier for the teacher
    /// </summary>
    [Key]
    [Required]
    [Column("id")]
    public required Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the full name of the teacher
    /// </summary>
    [Required]
    [Column("full_name")]
    public required string FullName { get; set; }


    /// <summary>
    /// Gets or sets the teacher's phone number
    /// </summary>
    [Required]
    [Column("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// Gets or sets the teacher's email address
    /// </summary>
    [Required]
    [Column("personal_email")]
    [EmailAddress]
    public required string PersonalEmailAddress { get; set; }


    /// <summary>
    /// Gets or sets the teacher's business email address
    /// </summary>
    [Required]
    [Column("business_email")]
    [EmailAddress]
    public required string BusinessEmailAddress { get; set; }

    /// <summary>
    /// Navigate property for schedules associated with the teacher
    /// </summary>
    public List<Schedule> Schedules { get; set; } = [];
}
