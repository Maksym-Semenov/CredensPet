using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class ContactRepository : IRepository<ContactDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToContact;

    public ContactRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<Contact, ContactDTO>.MapTo();
        _mapperToContact = GenericMapperConfiguration<ContactDTO, Contact>.MapTo();
    }

    public async Task AddAsync(ContactDTO entity)
    {
        var contactDTO = _mapperToContact.Map<Contact>(entity);
        _context.Contacts.Add(contactDTO);
    }

    public async Task DeleteAsync(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public ContactDTO Find(params object[] keys)
    {
        return _mapperToDTO.Map<ContactDTO>(_context.Contacts.Find(keys));
    }

    public IQueryable<ContactDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<ContactDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public Task<ContactDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        var contact = _mapperToDTO.Map<IEnumerable<ContactDTO>>(_context.Contacts);
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

    public async Task UpdateAsync(ContactDTO entity)
    {
        throw new NotImplementedException();
    }
   
}