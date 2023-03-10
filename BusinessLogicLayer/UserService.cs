using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class UserService : IService<UserDTO>
{
    private readonly IRepository<UserDTO> _repository;

    public UserService(IRepository<UserDTO> repository)
    {
        _repository = repository;
    }


    public virtual async Task AddAsync(UserDTO entity)
    {
        await _repository.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(UserDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public IQueryable<UserDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(UserDTO entity)
    {
        await _repository.UpdateAsync(entity);
    }

}