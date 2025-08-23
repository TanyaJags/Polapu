using System.ComponentModel.DataAnnotations;

namespace Core.API.Model;

public class CandidateDto
{
    public CandidateDto() { }  

    public string Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public String Email { get; set; }
    [Phone]
    public String Phone { get; set; }
    public string ResumeUrl { get; set; }
    public CandidateStatus Status { get; set; }
}
