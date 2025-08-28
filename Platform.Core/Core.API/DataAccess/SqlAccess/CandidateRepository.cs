using System.Net;
using Core.API.Entity;
using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public class CandidateRepository : ICandidateRepository
{
    private IQueryable<CandidateDto> candidates;
    private readonly AppDbContext _db;
    public CandidateRepository(AppDbContext context)
    {
        _db = context;
    }
    public IQueryable<Candidate> GetCandidates()
    {
        return _db.Candidates;
    }

    public Candidate? GetById(int id)
    {
        Candidate? candidate = _db.Candidates.Find(id);
        return candidate;
    }
    
    public HttpStatusCode Create(Candidate candidateDto)
    {
        _db.Candidates.Add(candidateDto);
        _db.SaveChanges();
        return HttpStatusCode.Created;
    }
    
    public HttpStatusCode UpdateInfo(Candidate candidate)
    {
        _db.Candidates.Update(candidate);
        _db.SaveChanges();
        return HttpStatusCode.OK;
    }
    
}