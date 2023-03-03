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
    private readonly IMapper _mapper;
    public ContactRepository(CredensContext context)
    {
        _context = context;
        _mapper = GenericMapperConfiguration<Contact, ContactDTO>.MapTo();
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        var contact = _mapper.Map<IEnumerable<ContactDTO>>(_context.Contacts);
        return contact;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public void Add(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ContactDTO entity)
    {
        throw new NotImplementedException();
    }
   
}