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

    public void Add(ProjectDTO entity)
    {
        var project = _mapper2.Map<Project>(entity);
        _context.Projects.Add(project);
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

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task<ProjectDTO> FindAsync(int? id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var project = _mapper2.Map<ProjectDTO>(_context.Projects.FindAsync(id));

        if (project == null)
        {
            throw new InvalidOperationException();
        }
        
        return project;
    }
}