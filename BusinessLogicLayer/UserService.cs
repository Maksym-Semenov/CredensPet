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

    public void Add(UserDTO entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }
   
    public void Delete(UserDTO entity)
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

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }

}