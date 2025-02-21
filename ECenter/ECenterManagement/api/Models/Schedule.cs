using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

/// <summary>
/// Represents a schedule in the system
/// </summary>
public class Schedule
{
    /// <summary>
    /// Gets or sets the unique identifier for schedule
    /// </summary>
    [Key]
    [Required]
    public required Guid Id { get; set; }

    /// <summary>
    /// Navigation property to the associated teacher
    /// </summary>
    public required Guid TeacherId { get; set; }

    /// <summary>
    /// Navigate property to the associated teacher
    /// </summary>
    [Required]
    public required Teacher Teacher { get; set; }

    /// <summary>
    /// Gets or sets the schedule's class name
    /// </summary>
    [Required]
    public required string ClassName { get; set; }

    /// <summary>
    /// Gets or sets the schedule's start date
    /// </summary>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the schedule's end date
    /// </summary>
    [Required]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the subject being taught during this schedule
    /// </summary>
    [Required]
    public required string Subject { get; set; }
}
