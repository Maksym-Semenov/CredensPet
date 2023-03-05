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
    private readonly IMapper _mapper1;
    private readonly IMapper _mapper2;
    public ContactRepository(CredensContext context)
    {
        _context = context;
        _mapper1 = GenericMapperConfiguration<Contact, ContactDTO>.MapTo();
        _mapper2 = GenericMapperConfiguration<ContactDTO, Contact>.MapTo();
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        var contact = _mapper1.Map<IEnumerable<ContactDTO>>(_context.Contacts);
        return contact;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public async Task Add(ContactDTO entity)
    {
        var contact = _mapper2.Map<Contact>(entity);
        await _context.Contacts.AddAsync(contact);
    }

    public void Update(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}