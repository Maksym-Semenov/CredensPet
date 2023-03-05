using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.MappingProfiles;
using DataAccessLayer.Models;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class ProjectRepository : IRepository<ProjectDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapper1;
    private readonly IMapper _mapper2;
    public ProjectRepository(CredensContext context)
    {
        _context = context;
        _mapper1 = GenericMapperConfiguration<Project, ProjectDTO>.MapTo();
        _mapper2 = GenericMapperConfiguration<ProjectDTO, Project>.MapTo();
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var project = _mapper1.Map<IEnumerable<ProjectDTO>>(_context.Projects);
        return project;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public async Task Add(ProjectDTO entity)
    {
        var project = _mapper2.Map<Project>(entity);
        await _context.Projects.AddAsync(project);
    }

    public void Update(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
      return _context.SaveChangesAsync();
    }
}