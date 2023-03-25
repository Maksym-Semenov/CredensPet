using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class AddressProjectService : IService<AddressProjectDTO>
{
    private readonly IRepository<AddressProjectDTO> _repository;

    public AddressProjectService(IRepository<AddressProjectDTO> repository)
    {
        _repository = repository;
    }

    public virtual async Task AddAsync(AddressProjectDTO entity)
    {
        await _repository.AddAsync(entity);
    }
  
    public virtual async Task DeleteAsync(AddressProjectDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public IQueryable<AddressProjectDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(AddressProjectDTO entity)
    {
        await _repository.UpdateAsync(entity); 
    }

}