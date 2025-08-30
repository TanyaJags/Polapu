using Core.API.Model;

namespace Core.API.DataAccess.SqlAccess;

public interface IRecruiterRepository
{
    public Recruiter Create(Recruiter recruiter);
}