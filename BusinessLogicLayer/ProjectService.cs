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

    public async Task AddAsync(ProjectDTO entity)
    {
        _repository.AddAsync(entity);
        _repository.SaveChanges();
    }

    public async Task DeleteAsync(ProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public ProjectDTO Find(params object[] keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }
        return _repository.Find(keys);
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
        var projectDTO = _repository.GetAll();
        return projectDTO;
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
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