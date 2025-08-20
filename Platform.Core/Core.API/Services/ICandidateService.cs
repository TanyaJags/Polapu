using System.Net;
using Core.API.Model;

namespace Core.API.Services;

public interface ICandidateService
{
    public  IEnumerable<Candidate> GetCandidates(CandidateStatus? status);
    public Candidate? GetById(int id);
    public HttpStatusCode Create(Candidate candidate);
    public HttpStatusCode UpdateInfo(Candidate candidate);
    public HttpStatusCode UpdateStatus(int id, CandidateStatus status);

}