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


    public virtual async Task AddAsync(ProjectDTO entity)
    {
        await _repository.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(ProjectDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public IQueryable<ProjectDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(ProjectDTO entity)
    {
        await _repository.UpdateAsync(entity);
    }

}