using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("rooms")]
    public class Rooms
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        [Required]
        [Column("no")]
        public required string No { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
