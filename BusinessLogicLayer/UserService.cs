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

    public async Task AddAsync(UserDTO entity)
    {
        _repository.AddAsync(entity);
        _repository.SaveChanges();
    }
   
    public async Task DeleteAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public UserDTO Find(params object[] keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }
        return _repository.Find(keys);
    }

    public IQueryable<UserDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<UserDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public virtual Task<UserDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserDTO> GetAll()
    {
        var userDTO = _repository.GetAll();
        return userDTO;
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

}