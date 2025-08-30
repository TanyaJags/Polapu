using Core.API.DataAccess.SqlAccess;
using Core.API.Model;
using Core.API.Utilities;
using MapsterMapper;

namespace Core.API.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public User? GetById(int id)
    {
        var result = _userRepository.GetById(id);
        if (result == null)
        {
            return null;
        }
        return result;
    }

    public User Create(UserDto user)
    {
        var userEntity = _mapper.Map<User>(user);
        userEntity.PasswordHashed = PasswordHasher.HashPassword(user.password);
        var result = _userRepository.Create(userEntity);
        return result;
    }
}