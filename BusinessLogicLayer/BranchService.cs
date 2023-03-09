using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class BranchService : IService<BranchDTO>
{
    private readonly IRepository<BranchDTO> _repository;

    public BranchService(IRepository<BranchDTO> repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(BranchDTO entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task DeleteAsync(BranchDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public BranchDTO Find(params object[] keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }
        return _repository.Find(keys);
    }

    public IQueryable<BranchDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual Task<BranchDTO> FindAsync(params object[] keys)
    {
        return _repository.FindAsync(keys);
    }

    public virtual  Task<BranchDTO> FirstOrDefault(params object[] keys)
    {
        return _repository.FirstOrDefault(keys);
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _repository.GetAll();

        if (branchDTO == null)
            throw new ArgumentNullException();
        
        return branchDTO;
    }


    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public virtual Task SaveChangesAsync()
    {
        return _repository.SaveChangesAsync();
    }

    public async Task UpdateAsync(BranchDTO entity)
    {
        await _repository.UpdateAsync(entity);
    }
   
}