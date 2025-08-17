namespace Core.API.Model;

public class Candidate
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public String Email { get; set; }
    public String Phone { get; set; }
    public string ResumeUrl { get; set; }
    public CandidateStatus Status { get; set; }
}
