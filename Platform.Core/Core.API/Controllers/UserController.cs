using Core.API.Model;
using Core.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService =  userService;
    }
    // GET
    [HttpPost]
    public ActionResult<User> Create(UserDto userDto)
    {
        var result = _userService.Create(userDto);
        return StatusCode(StatusCodes.Status201Created, result);    
    }

    [HttpGet]
    public ActionResult<User> GetById(int id)
    {
        var result = _userService.GetById(id);
        return Ok(result);
    }
}