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


    public virtual async Task AddAsync(BranchDTO entity)
    {
        await _repository.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(BranchDTO entity)
    {
        await _repository.DeleteAsync(entity);
    }

    public IQueryable<BranchDTO> FindAll()
    {
        return _repository.FindAll();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(BranchDTO entity)
    {
        await _repository.UpdateAsync(entity);
    }
   
}