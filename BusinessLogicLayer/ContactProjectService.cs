using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ContactProjectService : IService<ContactProjectDTO>
{
    private readonly IRepository<ContactProjectDTO> _repository;

    public ContactProjectService(IRepository<ContactProjectDTO> repository)
    {
        _repository = repository;
    }

    public virtual async Task AddAsync(ContactProjectDTO entity)
    {
        await _repository.AddAsync(entity);
    }
  
    public virtual async Task DeleteAsync(ContactProjectDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public IQueryable<ContactProjectDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(ContactProjectDTO entity)
    {
        await _repository.UpdateAsync(entity); 
    }

}