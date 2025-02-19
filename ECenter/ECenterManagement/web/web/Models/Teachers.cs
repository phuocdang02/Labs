namespace web.Models
{
    public class Teachers
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PersonalEmailAddress { get; set; } = string.Empty;
        public string BusinessEmailAddress { get; set; } = string.Empty;
        public List<Schedules>? Schedules { get; set; }
    }
}
