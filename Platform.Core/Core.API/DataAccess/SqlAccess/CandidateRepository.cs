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

    // public CandidateDto? GetById(int id)
    // {
    //     CandidateDto? candidate = _db.Candidate.Find(id);
    //     return candidate;
    // }
    //
    // public HttpStatusCode Create(CandidateDto candidateDto)
    // {
    //     _db.Candidate.Add(candidateDto);
    //     _db.SaveChanges();
    //     return HttpStatusCode.Created;
    // }
    //
    // public HttpStatusCode UpdateInfo(CandidateDto candidateDto)
    // {
    //     _db.Candidate.Update(candidateDto);
    //     _db.SaveChanges();
    //     return HttpStatusCode.OK;
    // }
    //
    // public HttpStatusCode UpdateStatus(int id, CandidateStatus status)
    // {
    //     //chang this logic
    //     //var candidate = GetById(id);
    //     //if (candidate != null)
    //     //{
    //     //    candidate.Status = status; // Update the status
    //     //    return HttpStatusCode.OK;
    //     //}
    //     return HttpStatusCode.NotFound;
    // }
}