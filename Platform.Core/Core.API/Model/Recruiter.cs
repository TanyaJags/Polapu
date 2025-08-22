namespace Core.API.Model
{
    public class Recruiter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<CandidateDto> CandidatesScheduled { get; set; }
    }
}