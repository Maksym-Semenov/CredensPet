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
        var userDTO = _repository.Find(keys);
        return userDTO;
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

    public void Update(UserDTO entity)
    {
        throw new NotImplementedException();
    }

}