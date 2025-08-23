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
    public ActionResult<IEnumerable<CandidateDto>> GetAll([FromQuery] CandidateStatus? status)
    {
        var results = _candidateService.GetCandidates(status);        
        return Ok(results);
    }

    [HttpGet("{id}")]
    public ActionResult<CandidateDto> GetById(int id)
    {
        var result = _candidateService.GetById(id);
        return Ok(result);
    }
    
    // [HttpPost]
    // public ActionResult<CandidateDto> Create([FromBody] CandidateDto candidateDto)
    // {
    //     var result = _candidateService.Create(candidateDto);
    //     return Ok(result);
    // }
    //
    // [HttpPut]
    // public ActionResult<CandidateDto> UpdateInfo([FromBody] CandidateDto candidateDto)
    // {
    //     var result = _candidateService.UpdateInfo(candidateDto);
    //     return Ok();
    // }
    //
    // [HttpPatch]
    // public ActionResult<CandidateDto> UpdateStatus([FromBody] int id, CandidateStatus status)
    // {
    //     var result = _candidateService.UpdateStatus(id,status );
    //     return NotFound();
    // }
}