using AutoMapper;
using AutoMapper.QueryableExtensions;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class ContactUserRepository : IRepository<ContactUserDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToContactUser;

    public ContactUserRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<ContactUser, ContactUserDTO>.MapTo();
        _mapperToContactUser = GenericMapperConfiguration<ContactUserDTO, ContactUser>.MapTo();
    }


    public virtual async Task AddAsync(ContactUserDTO entity)
    {
        await _context.ContactUsers.AddAsync(_mapperToContactUser.Map<ContactUser>(entity));
    }

    public virtual async Task DeleteAsync(ContactUserDTO entity)
    {
        _context.ContactUsers.Remove(_mapperToContactUser.Map<ContactUser>(entity));
    }

    public IQueryable<ContactUserDTO> FindAll()
    {
        return _context.ContactUsers.ProjectTo<ContactUserDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(ContactUserDTO entity)
    {
        _context.Entry(_mapperToContactUser.Map<ContactUser>(entity)).State = EntityState.Modified;
    }
   
}