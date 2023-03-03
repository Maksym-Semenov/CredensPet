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
    private readonly IMapper _mapper;
    public ProjectRepository(CredensContext context)
    {
        _context = context;
        _mapper = GenericMapperConfiguration<Project, ProjectDTO>.MapTo();
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var project = _mapper.Map<IEnumerable<ProjectDTO>>(_context.Projects);
        return project;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public void Add(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }
   
}