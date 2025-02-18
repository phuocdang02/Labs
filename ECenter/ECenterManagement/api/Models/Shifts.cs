using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("shifts")]
    public class Shifts
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("shift_code")]
        public string ShiftCode { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }
    }
}