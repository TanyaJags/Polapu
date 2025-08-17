using Core.API.DataAccess.SqlAccess;
using Core.API.Model;

namespace Core.API.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _repository;
    public CandidateService(ICandidateRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<Candidate> GetCandidates()
    {
        var candidates = _repository.GetCandidates();
        return candidates;
    }

    public Candidate? GetById(int id)
    {
        Candidate? candidate = _repository.GetById(id);
        return candidate;
    }
}