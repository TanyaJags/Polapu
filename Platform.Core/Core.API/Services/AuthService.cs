using Core.API.DataAccess.SqlAccess;
using Core.API.Model;
using Core.API.Utilities;

namespace Core.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User? Authenticate(string email, string password )
    {
        var user = _userRepository.GetByEmail(email);
        if (user == null)
            return null;
        PasswordHasher.VerifyPassword(password,user.PasswordHashed);
        return user;
    }

    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }
}