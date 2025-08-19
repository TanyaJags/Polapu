using System.Net;
using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public class CandidateRepository : ICandidateRepository
{
    private IQueryable<Candidate> candidates;
    public CandidateRepository()
    {
        candidates = new List<Candidate>
        {
            new Candidate
            {
                Email = "tanya.sharma@hotmail.com",
                Id = 1,
                Name = new Name
                {
                    FirstName = "Tanya",
                    LastName = "Sharma"
                },
                Phone = "7550211805",
                ResumeUrl = "xyz.url.com",
                Status = CandidateStatus.Applied
            }
        }.AsQueryable();
    }
    public IQueryable<Candidate> GetCandidates()
    {
        return candidates;
    }

    public Candidate? GetById(int id)
    {
        Candidate? candidate = GetCandidates().FirstOrDefault(c => c.Id == id);
        return candidate;
    }

    public HttpStatusCode Create(Candidate candidate)
    {
        var list = candidates.ToList();
        list.Add(candidate);
        candidates = list.AsQueryable();
        return HttpStatusCode.Created;
    }
}