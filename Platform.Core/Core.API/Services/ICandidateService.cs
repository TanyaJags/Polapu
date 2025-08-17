using Core.API.Model;

namespace Core.API.Services;

public interface ICandidateService
{
    public IEnumerable<Candidate> GetCandidates();
    public Candidate? GetById(int id);
}