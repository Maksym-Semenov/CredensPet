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

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _repository.GetAll();
        return branchDTO;
    }

    public void Add(BranchDTO entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public Task<BranchDTO> FindAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public void Update(BranchDTO entity)
    {
        throw new NotImplementedException();
    }
}