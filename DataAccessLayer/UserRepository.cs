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
    private readonly IMapper _mapperForward;
    private readonly IMapper _mapperBackward;

    public UserRepository(CredensContext context)
    {
        _context = context;
        _mapperForward = GenericMapperConfiguration<User, UserDTO>.MapTo();
        _mapperBackward = GenericMapperConfiguration<UserDTO, User>.MapTo();
    }

    public void Add(UserDTO entity)
    {
        var userDTO = _mapperBackward.Map<User>(entity);
        _context.Add(userDTO);
    }

    public void Delete(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public UserDTO Find(params object[] keys)
    {
        var userDTO = _mapperForward.Map<UserDTO>(_context.Users.Find(keys));
        return userDTO;
    }

    public IEnumerable<UserDTO> GetAll()
    {
        var userDTO = _mapperForward.Map<IEnumerable<UserDTO>>(_context.Users);
        return userDTO;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }

}