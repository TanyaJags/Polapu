using System.Net;
using Core.API.Entity;
using Core.API.Model;

namespace Core.API.Services;

public interface ICandidateService
{
    public  IEnumerable<CandidateDto> GetCandidates(CandidateStatus? status);
    public CandidateDto? GetById(int id);
    public Candidate Create(CandidateInfoDto candidateDto);
    public HttpStatusCode UpdateInfo(CandidateDto candidateDto);
    public HttpStatusCode UpdateStatus(int id, CandidateStatus status);

}