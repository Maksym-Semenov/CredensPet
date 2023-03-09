using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ContactService : IService<ContactProjectDTO>
{
    private readonly IRepository<ContactProjectDTO> _repository;

    public ContactService(IRepository<ContactProjectDTO> repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(ContactProjectDTO entity)
    {
        await _repository.AddAsync(entity);
    }
  
    public async Task DeleteAsync(ContactProjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public ContactProjectDTO Find(params object[] keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }
        return _repository.Find(keys);
    }

    public IQueryable<ContactProjectDTO> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual Task<ContactProjectDTO> FindAsync(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public virtual Task<ContactProjectDTO> FirstOrDefault(params object[] keys)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ContactProjectDTO> GetAll()
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

    public async Task UpdateAsync(ContactProjectDTO entity)
    {
        throw new NotImplementedException();
    }

}