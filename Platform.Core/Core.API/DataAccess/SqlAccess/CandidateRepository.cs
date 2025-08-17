using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public class CandidateRepository : ICandidateRepository
{
    public IQueryable<Candidate> GetCandidates()
    {
        var candidates = new List<Candidate>
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
        return candidates;
    }

    public Candidate? GetById(int id)
    {
        Candidate? candidate = GetCandidates().FirstOrDefault(c => c.Id == id);
        return candidate;
    }
}