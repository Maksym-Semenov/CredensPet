using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ContactService : IService<ContactDTO>
{
    private readonly IRepository<ContactDTO> _repository;

    public ContactService(IRepository<ContactDTO> repository)
    {
        _repository = repository;
    }

    public void Add(ContactDTO entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }
  
    public void Delete(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public ContactDTO Find(params object[] keys)
    {
        var contactDTO = _repository.Find(keys);
        return contactDTO;
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        var contactDTO = _repository.GetAll();
        return contactDTO;
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public void Update(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

}