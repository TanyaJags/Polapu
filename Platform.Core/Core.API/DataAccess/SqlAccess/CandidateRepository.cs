using System.Net;
using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public class CandidateRepository : ICandidateRepository
{
    private IQueryable<Candidate> candidates;
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

    public HttpStatusCode Create(Candidate candidate)
    {
        _db.Candidates.Add(candidate);
        _db.SaveChanges();
        return HttpStatusCode.Created;
    }

    public HttpStatusCode UpdateInfo(Candidate candidate)
    {
        _db.Candidates.Update(candidate);
        _db.SaveChanges();
        return HttpStatusCode.OK;
    }

    public HttpStatusCode UpdateStatus(int id, CandidateStatus status)
    {
        //chang this logic
        //var candidate = GetById(id);
        //if (candidate != null)
        //{
        //    candidate.Status = status; // Update the status
        //    return HttpStatusCode.OK;
        //}
        return HttpStatusCode.NotFound;
    }
}