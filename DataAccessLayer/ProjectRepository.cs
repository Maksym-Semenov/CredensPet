using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
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

    public async Task AddAsync(ProjectDTO entity)
    {
        var projectDTO = _mapperToProject.Map<Project>(entity);
        _context.Projects.Add(projectDTO);
    }

    public async Task DeleteAsync(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public ProjectDTO Find(params object[] keys)
    {
         return _mapperToDTO.Map<ProjectDTO>(_context.Projects.Find(keys));
    }

    public IQueryable<ProjectDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<ProjectDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public virtual Task<ProjectDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var projectDTO = _mapperToDTO.Map<IEnumerable<ProjectDTO>>(_context.Projects);
        return projectDTO;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

}