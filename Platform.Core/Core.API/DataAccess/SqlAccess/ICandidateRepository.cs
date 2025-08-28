using System.Net;
using Core.API.Entity;
using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public interface ICandidateRepository
{
    public IQueryable<Candidate> GetCandidates();
    public Candidate? GetById(int id);
    public HttpStatusCode Create(Candidate candidateDto);
    public HttpStatusCode UpdateInfo(Candidate candidate);
}