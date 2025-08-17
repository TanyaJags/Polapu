using Core.API.Model;
using Core.API.Services;
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
    public ActionResult<IEnumerable<Candidate>> GetAll()
    {
        var results = _candidateService.GetCandidates();        
        return Ok(results);
    }

    [HttpGet("{id}")]
    public ActionResult<Candidate> GetById(int id)
    {
        var result = _candidateService.GetById(id);
        return Ok(result);
    }
}