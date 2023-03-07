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

    public IEnumerable<ContactDTO> GetAll()
    {
        var contactDTO = _repository.GetAll();
        return contactDTO;
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

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public Task<ContactDTO> FindAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public void Update(ContactDTO entity)
    {
        throw new NotImplementedException();
    }
}