using Core.API.Entity;
using MapsterMapper;

namespace Core.API.Model;

public class CandidateDto
{
    public CandidateDto() { }  

    public string Id { get; set; }
    public string Name { get; set; }
    public String Email { get; set; }
    public String Phone { get; set; }
    public string ResumeUrl { get; set; }
    public CandidateStatus Status { get; set; }
}
