using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ProjectService : IService<ProjectDTO>
{
    private readonly IRepository<ProjectDTO> _repository;

    public ProjectService(IRepository<ProjectDTO> repository)
    {
        _repository = repository;
    }

    public void Add(ProjectDTO entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }

    public void Delete(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public async Task<ProjectDTO> FindAsync(int? id)
    {
        var project = _repository.FindAsync(id);
        return await project;
    }

    public IEnumerable<ProjectDTO> GetAll()
    {
        var projectDTO = _repository.GetAll();
        return projectDTO;
    }

    public void Update(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }
}