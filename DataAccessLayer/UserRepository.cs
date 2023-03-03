using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class UserRepository : IRepository<UserDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapper;
    public UserRepository(CredensContext context)
    {
        _context = context;
        _mapper = GenericMapperConfiguration<User, UserDTO>.MapTo();
    }

    public IEnumerable<UserDTO> GetAll()
    {
        var user = _mapper.Map<IEnumerable<UserDTO>>(_context.Users);
        return user;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public void Add(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(UserDTO entity)
    {
        throw new NotImplementedException();
    }
   
}