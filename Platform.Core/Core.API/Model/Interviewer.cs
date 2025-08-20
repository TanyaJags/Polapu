namespace Core.API.Model
{
    public class Interviewer
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public string Email { get; set; }
        public string TeamsId { get; set; }
        public IEnumerable<Guid> InterviewIds { get; set; }
    }
}