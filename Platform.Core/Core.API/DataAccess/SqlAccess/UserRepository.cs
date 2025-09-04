using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }
    public User? GetById(int id)
    {
        return _db.Users.Find(id);
    }

    public User GetByEmail(string email)
    {
        return _db.Users.FirstOrDefault(u => u.Email == email);
    }

    public User Create(User user)
    {
         _db.Users.Add(user);
         _db.SaveChanges();
        return user;
    }
}