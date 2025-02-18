using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("shifts")]
    public class TimeShifts
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("time_shift_code")]
        public string TimeShiftCode { get; set; }

        [Required]
        [Column("time_from")]
        public TimeOnly TimeFrom { get; set; }

        [Required]
        [Column("time_to")]
        public TimeOnly TimeTo { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Day type information for shift
    /// </summary>
    public enum DayType
    {
        /// <summary>
        /// Even date
        /// </summary>
        E,

        /// <summary>
        /// Odd date
        /// </summary>
        O,

        /// <summary>
        /// Weekend date
        /// </summary>
        W
    }
}