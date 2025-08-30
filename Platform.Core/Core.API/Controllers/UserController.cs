using Core.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IRecruiterService _recruiterService;

    public UserController(IRecruiterService recruiterService)
    {
        _recruiterService = recruiterService;
    }
    // GET
    [HttpGet]
    public ActionResult GetRecruiters()
    {
        return Ok();
    }
}