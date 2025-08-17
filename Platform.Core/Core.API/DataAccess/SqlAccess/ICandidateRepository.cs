using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public interface ICandidateRepository
{
    public IQueryable<Candidate> GetCandidates();
    public Candidate? GetById(int id);

}