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
    private readonly IMapper _mapperForward;
    private readonly IMapper _mapperBackward;

    public ProjectRepository(CredensContext context)
    {
        _context = context;
        _mapperForward = GenericMapperConfiguration<Project, ProjectDTO>.MapTo();
        _mapperBackward = GenericMapperConfiguration<ProjectDTO, Project>.MapTo();
    }

    public void Add(ProjectDTO entity)
    {
        var projectDTO = _mapperBackward.Map<Project>(entity);
        _context.Projects.Add(projectDTO);
    }

    public void Delete(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public ProjectDTO Find(params object[] keys)
    {
        var projectDTO = _mapperForward.Map<ProjectDTO>(_context.Projects.Find(keys));
        return projectDTO;
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var projectDTO = _mapperForward.Map<IEnumerable<ProjectDTO>>(_context.Projects);
        return projectDTO;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

}