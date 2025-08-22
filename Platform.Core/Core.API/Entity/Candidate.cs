using Core.API.Model;

namespace Core.API.Entity;

public class Candidate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public String Email { get; set; }
    public String Phone { get; set; }
    public string ResumeUrl { get; set; }
    public CandidateStatus Status { get; set; }
}