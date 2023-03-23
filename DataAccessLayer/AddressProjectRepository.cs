using AutoMapper;
using AutoMapper.QueryableExtensions;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class AddressProjectRepository : IRepository<AddressProjectDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToAddressProject;

    public AddressProjectRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<AddressProject, AddressProjectDTO>.MapTo();
        _mapperToAddressProject = GenericMapperConfiguration<AddressProjectDTO, AddressProject>.MapTo();
    }

    public virtual async Task AddAsync(AddressProjectDTO entity)
    {
        await _context.AddressProjects.AddAsync(_mapperToAddressProject.Map<AddressProject>(entity));
    }

    public virtual async Task DeleteAsync(AddressProjectDTO entity)
    {
        _context.AddressProjects.Remove(_mapperToAddressProject.Map<AddressProject>(entity));
    }

    public IQueryable<AddressProjectDTO> FindAll()
    {
        return _context.AddressProjects.ProjectTo<AddressProjectDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(AddressProjectDTO entity)
    {
        _context.Entry(_mapperToAddressProject.Map<AddressProject>(entity)).State = EntityState.Modified;
    }
   
}