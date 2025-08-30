using Core.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Services;

public interface IRecruiterService
{
    public Recruiter Create(RecuiterDto recruiterDto);
    public Recruiter GetById(int id);
}   