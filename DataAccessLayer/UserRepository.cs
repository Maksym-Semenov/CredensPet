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
    private readonly IMapper _mapper1;
    private readonly IMapper _mapper2;
    public UserRepository(CredensContext context)
    {
        _context = context;
        _mapper1 = GenericMapperConfiguration<User, UserDTO>.MapTo();
        _mapper2 = GenericMapperConfiguration<UserDTO, User>.MapTo();
    }

    public IEnumerable<UserDTO> GetAll()
    {
        var user = _mapper1.Map<IEnumerable<UserDTO>>(_context.Users);
        return user;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public async Task Add(UserDTO entity)
    {
        var user = _mapper2.Map<User>(entity);
        await _context.Users.AddAsync(user);
    }

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}