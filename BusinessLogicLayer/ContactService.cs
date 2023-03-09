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

    public async Task AddAsync(ContactDTO entity)
    {
        _repository.AddAsync(entity);
        _repository.SaveChanges();
    }
  
    public async Task DeleteAsync(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public ContactDTO Find(params object[] keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }
        return _repository.Find(keys);
    }

    public IQueryable<ContactDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<ContactDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public virtual Task<ContactDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
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

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

}