using Core.API.Model;
using Core.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _authService.Authenticate(request.Email, request.Password);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _authService.GenerateToken(user);

        var response = new LoginResponse
        {
            Token = token,
            Email = user.Email,
            Role = user.Role.ToString()
        };

        return Ok(response);
    }
}