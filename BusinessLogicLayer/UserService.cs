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

    public void Add(UserDTO entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }

    public void Delete(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public Task<UserDTO> FindAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }
}