using Core.API.Model;
using Core.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;

[ApiController]
[Route("[controller]")]

public class RecruiterController : Controller
{
    private readonly IRecruiterService _recruiterService;

    public RecruiterController(IRecruiterService recruiterService)
    {
        _recruiterService = recruiterService;
    }
    
    [HttpPost]
    public ActionResult CreateRecruiter(RecuiterDto recuiterDto)
    {
        var recruiter = _recruiterService.Create(recuiterDto);
        if (recruiter == null)
            return BadRequest();
        
        return CreatedAtAction(nameof(GetById), new { id = recruiter.Id }, recruiter);    
    }
    
    [HttpGet("{id}")]

    public ActionResult<Recruiter> GetById(int id)
    {
        var recruiter = _recruiterService.GetById(id);
        if (recruiter == null)
            return NotFound();
        return Ok(recruiter);
        
    }
}
   