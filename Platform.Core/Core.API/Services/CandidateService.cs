using System.Net;
using Azure.Storage.Blobs;
using Core.API.DataAccess.BlobAccess;
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
    private readonly BlobService _blobServiceClient;
    public CandidateService(ICandidateRepository repository, IMapper mapper, BlobService blobService)
    {
        _repository = repository;
        _mapper = mapper;
        _blobServiceClient = blobService;
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
        var doesExists = _repository.GetCandidates()
            .Any(c => c.Name == candidateDto.Name && c.Email == candidateDto.Email);
        if (!doesExists)
            return null;
        string resumeUrl = _blobServiceClient.UploadFile(candidateDto.Resume);
        var candidate = _mapper.Map<Candidate>(candidateDto);
        candidate.Status = CandidateStatus.Applied;
        candidate.ResumeUrl = resumeUrl;
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