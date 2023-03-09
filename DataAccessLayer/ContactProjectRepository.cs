using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class ContactProjectRepository : IRepository<ContactProjectDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToContact;

    public ContactProjectRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<ContactProject, ContactProjectDTO>.MapTo();
        _mapperToContact = GenericMapperConfiguration<ContactProjectDTO, ContactProject>.MapTo();
    }

    public async Task AddAsync(ContactProjectDTO entity)
    {
        var contactDTO = _mapperToContact.Map<ContactProject>(entity);
        await _context.ContactProjects.AddAsync(contactDTO);
    }

    public async Task DeleteAsync(ContactProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public ContactProjectDTO Find(params object[] keys)
    {
        return _mapperToDTO.Map<ContactProjectDTO>(_context.ContactProjects.Find(keys));
    }

    public IQueryable<ContactProjectDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<ContactProjectDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public Task<ContactProjectDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactProjectDTO> GetAll()
    {
        var contact = _mapperToDTO.Map<IEnumerable<ContactProjectDTO>>(_context.ContactProjects);
        return contact;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ContactProjectDTO entity)
    {
        throw new NotImplementedException();
    }
   
}