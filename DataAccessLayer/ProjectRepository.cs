using CredensPet.Infrastructure;
using DataAccessLayer.EF;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository;

public class ProjectRepository : IRepository<Project>
{
    private readonly CredensTestContext _context;
    public ProjectRepository(CredensTestContext context)
    {
        _context = context;
    }

    IEnumerable<Project> IRepository<Project>.GetAll()
    {
        return _context.Projects;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public void Add(Project entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Project entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Project entity)
    {
        throw new NotImplementedException();
    }
   
}