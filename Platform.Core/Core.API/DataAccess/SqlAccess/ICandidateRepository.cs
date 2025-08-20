using System.Net;
using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public interface ICandidateRepository
{
    public IQueryable<Candidate> GetCandidates();
    public Candidate? GetById(int id);
    public HttpStatusCode Create(Candidate candidate);
    public HttpStatusCode UpdateInfo(Candidate candidate);
    public HttpStatusCode UpdateStatus(int id, CandidateStatus status);

}