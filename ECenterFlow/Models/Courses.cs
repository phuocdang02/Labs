using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECenterFlow.Models
{
    [Table("courses")]
    public class Courses
    {
        [Key]
        [Column("id")]
        public required Guid Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
