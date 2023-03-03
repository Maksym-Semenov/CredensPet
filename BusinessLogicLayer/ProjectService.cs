using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ProjectService : IService<ProjectDTO>
{
    private readonly IRepository<ProjectDTO> _projectRepository;

    public ProjectService(IRepository<ProjectDTO> projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public void Add(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var projectDTO = _projectRepository.GetAll();
        return projectDTO;
    }

    public void Update(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }
}