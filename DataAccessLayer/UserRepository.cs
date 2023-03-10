using AutoMapper;
using AutoMapper.QueryableExtensions;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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


    public virtual async Task AddAsync(UserDTO entity)
    {
        await _context.Users.AddAsync(_mapperToUser.Map<User>(entity));
    }

    public virtual async Task DeleteAsync(UserDTO entity)
    {
        _context.Users.Remove(_mapperToUser.Map<User>(entity));
    }

    public IQueryable<UserDTO> FindAll()
    {
        return _context.Users.ProjectTo<UserDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(UserDTO entity)
    {
        _context.Entry(_mapperToUser.Map<User>(entity)).State = EntityState.Modified;
    }

}