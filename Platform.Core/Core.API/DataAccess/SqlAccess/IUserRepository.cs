using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public interface IUserRepository
{
    public User GetById(int id);
    public User Create(User user);
}