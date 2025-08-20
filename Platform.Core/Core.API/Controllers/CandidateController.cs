using Core.API.Model;
using Core.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;
[ApiController]
[Route("[controller]")]
public class CandidateController : Controller
{
    private readonly ICandidateService _candidateService;
    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Candidate>> GetAll([FromQuery] CandidateStatus? status)
    {
        var results = _candidateService.GetCandidates(status);        
        return Ok(results);
    }

    [HttpGet("{id}")]
    public ActionResult<Candidate> GetById(int id)
    {
        var result = _candidateService.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Candidate> Create([FromBody] Candidate candidate)
    {
        var result = _candidateService.Create(candidate);
        return Ok(result);
    }

    [HttpPut]
    public ActionResult<Candidate> UpdateInfo([FromBody] Candidate candidate)
    {
        var result = _candidateService.UpdateInfo(candidate);
        return Ok();
    }

    [HttpPatch]
    public ActionResult<Candidate> UpdateStatus([FromBody] int id, CandidateStatus status)
    {
        var result = _candidateService.UpdateStatus(id,status );
        return NotFound();
    }
}