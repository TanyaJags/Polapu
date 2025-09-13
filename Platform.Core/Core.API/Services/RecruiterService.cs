using Core.API.DataAccess.SqlAccess;
using Core.API.Model;
using MapsterMapper;

namespace Core.API.Services;

public class RecruiterService : IRecruiterService
{
    private readonly IUserService _userService;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IMapper _mapper;

    public RecruiterService(IUserService userService, IRecruiterRepository recruiterRepository, IMapper mapper)
    {
        _userService = userService;
        _recruiterRepository = recruiterRepository;
        _mapper = mapper;
    }
    //Only system sould have access to create a recruiter
    public Recruiter? Create(RecuiterDto recruiterDto)
    {
        var user = _mapper.Map<UserDto>(recruiterDto);
        user.Role = UserProfile.Recruiter;
        var userresult = _userService.Create(user);
        if (userresult != null)
        {
            var recruiter = _mapper.Map<Recruiter>(recruiterDto);
            recruiter.Userid = userresult.Id.ToString();
            var result =  _recruiterRepository.Create(recruiter);
            return result;
        }
        return null;
    }

    //For UI or later use will susepend these APIs
    public Recruiter GetById(int id)
    {
        throw new NotImplementedException();
    }
}