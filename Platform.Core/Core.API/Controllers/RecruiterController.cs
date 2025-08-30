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
    public IActionResult CreateRecruiter(CandidateInfoDto candidateDto)
    {
        return Ok();
    }
}
   