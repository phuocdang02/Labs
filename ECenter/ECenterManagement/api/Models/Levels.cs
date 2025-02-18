using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("levels")]
    public class Levels
    {
        [Key]
        [Required]
        [Column("id")]
        public required Guid Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("course")]
        public required Guid Course { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
