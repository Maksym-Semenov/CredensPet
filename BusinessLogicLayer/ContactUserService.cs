using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ContactUserService : IService<ContactUserDTO>
{
    private readonly IRepository<ContactUserDTO> _repository;

    public ContactUserService(IRepository<ContactUserDTO> repository)
    {
        _repository = repository;
    }


    public virtual async Task AddAsync(ContactUserDTO entity)
    {
        await _repository.AddAsync(entity);
    }
  
    public virtual async Task DeleteAsync(ContactUserDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public IQueryable<ContactUserDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(ContactUserDTO entity)
    {
        await _repository.UpdateAsync(entity);
    }

}