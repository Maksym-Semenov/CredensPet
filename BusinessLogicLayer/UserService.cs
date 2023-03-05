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


    public IEnumerable<UserDTO> GetAll()
    {
        var user = _repository.GetAll();
        return user;
    }

    public async Task Add(UserDTO entity)
    {
        var user = _repository.Add(entity);
        await _repository.SaveChangesAsync();
    }

    public void Delete(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return _repository.SaveChangesAsync();
    }

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }
}