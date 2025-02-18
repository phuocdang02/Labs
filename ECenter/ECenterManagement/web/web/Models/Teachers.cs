using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Teachers
    {
        public required Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Phone { get; set; }
        public required string PersonalEmailAddress { get; set; }
        public required string BusinessEmailAddress { get; set; }
    }
}
