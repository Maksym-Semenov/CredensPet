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

    public async Task Add(ContactDTO entity)
    {
        var contact = _repository.Add(entity);
        await _repository.SaveChangesAsync();
    }

    public void Delete(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return _repository.SaveChangesAsync();
    }


    public void Update(ContactDTO entity)
    {
        throw new NotImplementedException();
    }
}