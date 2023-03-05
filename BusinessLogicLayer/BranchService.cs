using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.Models;

namespace BusinessLogicLayer;

public class BranchService : IService<BranchDTO>
{
    private readonly IRepository<BranchDTO> _repository;
    public BranchService(IRepository<BranchDTO> repository)
    {
        _repository = repository;
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _repository.GetAll();
        return branchDTO;
    }

    public async Task Add(BranchDTO entity)
    {
        await _repository.Add(entity);
        await _repository.SaveChangesAsync();
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }


    public void Update(BranchDTO entity)
    {
        throw new NotImplementedException();
    }
}