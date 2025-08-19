using System.Net;
using Core.API.Model;

namespace Core.API.Services;

public interface ICandidateService
{
    public IEnumerable<Candidate> GetCandidates(CandidateStatus? status);
    public Candidate? GetById(int id);
    public HttpStatusCode Create(Candidate candidate);
}