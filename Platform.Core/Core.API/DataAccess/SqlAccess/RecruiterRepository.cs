using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public class RecruiterRepository : IRecruiterRepository
{
    private readonly AppDbContext _db;
    public RecruiterRepository(AppDbContext db)
    {
        _db = db;
    }
    public Recruiter Create(Recruiter recruiter)
    {
        _db.Recruiters.Add(recruiter);
        _db.SaveChanges();
        return recruiter;
    }

    public Recruiter? GetById(int id)
    {
        return _db.Recruiters.Find(id);
    }
}