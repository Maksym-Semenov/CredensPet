using AutoMapper;
using AutoMapper.QueryableExtensions;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class ContactProjectRepository : IRepository<ContactProjectDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToContactProject;

    public ContactProjectRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<ContactProject, ContactProjectDTO>.MapTo();
        _mapperToContactProject = GenericMapperConfiguration<ContactProjectDTO, ContactProject>.MapTo();
    }

    public virtual async Task AddAsync(ContactProjectDTO entity)
    {
        await _context.ContactProjects.AddAsync(_mapperToContactProject.Map<ContactProject>(entity));
    }

    public virtual async Task DeleteAsync(ContactProjectDTO entity)
    {
        _context.ContactProjects.Remove(_mapperToContactProject.Map<ContactProject>(entity));
    }

    public IQueryable<ContactProjectDTO> FindAll()
    {
        return _context.ContactProjects.ProjectTo<ContactProjectDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(ContactProjectDTO entity)
    {
        _context.Entry(_mapperToContactProject.Map<ContactProject>(entity)).State = EntityState.Modified;
    }
   
}