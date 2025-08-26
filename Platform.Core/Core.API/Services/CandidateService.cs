using System.Net;
using Core.API.DataAccess.SqlAccess;
using Core.API.Entity;
using Core.API.Model;
using Mapster;
using MapsterMapper;

namespace Core.API.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _repository;
    private readonly IMapper _mapper;
    public CandidateService(ICandidateRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public IEnumerable<CandidateDto> GetCandidates(CandidateStatus? status)
    {
        var candidates = _repository.GetCandidates();

        if (status.HasValue)
        {
            candidates = candidates.Where(c => c.Status == status.Value);
        }
        return candidates.ProjectToType<CandidateDto>().ToList();
    }


    public CandidateDto? GetById(int id)
    {
        var candidate = _repository.GetById(id);
        if (candidate == null)
        {
            return null;
        }
        return _mapper.Map<CandidateDto>(candidate);
    }
    
    public Candidate? Create(CandidateInfoDto candidateDto)
    {
        var candidate = _mapper.Map<Candidate>(candidateDto);
        candidate.Status = CandidateStatus.Applied;
        HttpStatusCode result = _repository.Create(candidate);
        if (result != HttpStatusCode.Created)
        {
            return null;
        }
        return candidate;
    }
    
    // public HttpStatusCode UpdateInfo(CandidateDto candidateDto)
    // {
    //     // var candidates = _repository.GetCandidates().Where(c => c.Id == candidateDto.Id);
    //     // if (candidates.Any()) {
    //     //     var result = _repository.UpdateInfo(candidateDto);
    //     //     return HttpStatusCode.OK;
    //     // }
    //     return HttpStatusCode.NotFound;
    // }
    //
    // public HttpStatusCode UpdateStatus(int  id, CandidateStatus status)
    // {
    //     // var candidate = _repository.GetCandidates().Where(c => c.Id == id).FirstOrDefault();
    //     // if (candidate != null) {
    //     //     //change thi sstatus logic
    //     //     candidate.Status = CandidateStatus.InterviewScheduled; // Example status update
    //     //     var result = _repository.UpdateInfo(candidate);
    //     //     return HttpStatusCode.OK;
    //     // }
    //     return HttpStatusCode.NotFound;
    // }
}