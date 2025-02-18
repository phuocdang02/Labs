using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Schedules
    {
        public required Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
