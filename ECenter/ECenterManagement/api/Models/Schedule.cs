using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

/// <summary>
/// Represents a schedule in the system
/// </summary>
[Table("schedules")]
public class Schedule
{
    /// <summary>
    /// Gets or sets the unique identifier for schedule
    /// </summary>
    [Key]
    [Required]
    [Column("id")]
    public required Guid Id { get; set; }

    /// <summary>
    /// Navigation property to the associated teacher
    /// </summary>
    [ForeignKey("teacher_id")]
    public required Guid TeacherId { get; set; }

    /// <summary>
    /// Navigate property to the associated teacher
    /// </summary>
    [Required]
    [Column("TeacherId")]
    public required Teacher Teacher { get; set; }

    /// <summary>
    /// Gets or sets the schedule's class name
    /// </summary>
    [Required]
    [Column("class")]
    public required string ClassName { get; set; }

    /// <summary>
    /// Gets or sets the schedule's start date
    /// </summary>
    [Required]
    [Column("start_date")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the schedule's end date
    /// </summary>
    [Required]
    [Column("end_date")]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the subject being taught during this schedule
    /// </summary>
    [Required]
    [Column("subject")]
    public required string Subject { get; set; }
}
