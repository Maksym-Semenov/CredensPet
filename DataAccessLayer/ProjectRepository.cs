using AutoMapper;
using AutoMapper.QueryableExtensions;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class ProjectRepository : IRepository<ProjectDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToProject;

    public ProjectRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<Project, ProjectDTO>.MapTo();
        _mapperToProject = GenericMapperConfiguration<ProjectDTO, Project>.MapTo();
    }

    public virtual async Task AddAsync(ProjectDTO entity)
    {
        await _context.Projects.AddAsync(_mapperToProject.Map<Project>(entity));
    }

    public virtual async Task DeleteAsync(ProjectDTO entity)
    {
        _context.Projects.Remove(_mapperToProject.Map<Project>(entity));
    }

    public IQueryable<ProjectDTO> FindAll()
    {
        return _context.Projects.ProjectTo<ProjectDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(ProjectDTO entity)
    {
        _context.Entry(_mapperToProject.Map<Project>(entity)).State = EntityState.Modified;
    }

}