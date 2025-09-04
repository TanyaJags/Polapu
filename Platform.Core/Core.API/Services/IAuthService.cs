using Core.API.Model;

namespace Core.API.Services;

public interface IAuthService
{
    public User? Authenticate(string email, string password);
    public string GenerateToken(User user);
    
}