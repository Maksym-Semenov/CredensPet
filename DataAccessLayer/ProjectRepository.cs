using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.MappingProfiles;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository;

public class ProjectRepository : IRepository<ProjectDTO>
{
    private readonly CredensContext _context;
    public ProjectRepository(CredensContext context)
    {
        _context = context;
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var mapperConfiguration = new MapperConfiguration(x =>
            x.AddProfile<ProjectDTOMapperConfiguration>());
        var mapper = new Mapper(mapperConfiguration);
        var projectDTO = mapper.Map<IEnumerable<ProjectDTO>>(_context.Projects);
        return projectDTO;
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