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
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToUser;

    public UserRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<User, UserDTO>.MapTo();
        _mapperToUser = GenericMapperConfiguration<UserDTO, User>.MapTo();
    }

    public async Task AddAsync(UserDTO entity)
    {
        var userDTO = _mapperToUser.Map<User>(entity);
        _context.Add(userDTO);
    }

    public async Task DeleteAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public UserDTO Find(params object[] keys)
    {
        return _mapperToDTO.Map<UserDTO>(_context.Users.Find(keys));
    }

    public IQueryable<UserDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<UserDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public virtual Task<UserDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserDTO> GetAll()
    {
        var userDTO = _mapperToDTO.Map<IEnumerable<UserDTO>>(_context.Users);
        return userDTO;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

}