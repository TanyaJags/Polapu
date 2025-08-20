using System.Net;
using Core.API.DataAccess.SqlAccess;
using Core.API.Model;

namespace Core.API.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _repository;
    public CandidateService(ICandidateRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<Candidate> GetCandidates(CandidateStatus? status)
    {
        var candidates = _repository.GetCandidates();
        if (status == null)
        {
            return candidates;
        }
        else
        {
            return candidates.Where(c => c.Status != status.Value);
        }
    }

    public Candidate? GetById(int id)
    {
        Candidate? candidate = _repository.GetById(id);
        return candidate;
    }

    public HttpStatusCode Create(Candidate candidate)
    {
        HttpStatusCode result = _repository.Create(candidate);
        return result;
    }

    public HttpStatusCode UpdateInfo(Candidate candidate)
    {
        var candidates = _repository.GetCandidates().Where(c => c.Id == candidate.Id);
        if (candidates.Any()) {
            var result = _repository.UpdateInfo(candidate);
            return HttpStatusCode.OK;
        }
        return HttpStatusCode.NotFound;
    }

    public HttpStatusCode UpdateStatus(int  id, CandidateStatus status)
    {
        var candidate = _repository.GetCandidates().Where(c => c.Id == id).FirstOrDefault();
        if (candidate != null) {
            //change thi sstatus logic
            candidate.Status = CandidateStatus.InterviewScheduled; // Example status update
            var result = _repository.UpdateInfo(candidate);
            return HttpStatusCode.OK;
        }
        return HttpStatusCode.NotFound;
    }
}