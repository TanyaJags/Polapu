using Core.API.Model;

namespace Core.API.Services;

public interface IUserService
{
    public User GetById(int id);
    public User Create(UserDto user);
}