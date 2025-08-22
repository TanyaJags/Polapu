using System.Net;
using Core.API.Entity;
using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public interface ICandidateRepository
{
    public IQueryable<Candidate> GetCandidates();
    // public CandidateDto? GetById(int id);
    // public HttpStatusCode Create(CandidateDto candidateDto);
    // public HttpStatusCode UpdateInfo(CandidateDto candidateDto);
    // public HttpStatusCode UpdateStatus(int id, CandidateStatus status);

}