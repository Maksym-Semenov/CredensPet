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

    public async Task Add(ProjectDTO entity)
    {
        await _repository.Add(entity);
        await _repository.SaveChangesAsync();
    }

    public void Delete(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return _repository.SaveChangesAsync();
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