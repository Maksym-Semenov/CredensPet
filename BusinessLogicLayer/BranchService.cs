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

    public void Add(BranchDTO entity)
    {
        _repository.Add(entity);
        _repository.SaveChanges();
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public BranchDTO Find(params object[] keys)
    {
        var branchDTO = _repository.Find(keys);
        return branchDTO;
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _repository.GetAll();
        return branchDTO;
    }

    public void SaveChanges()
    {
        _repository.SaveChanges();
    }

    public void Update(BranchDTO entity)
    {
        _repository.Update(entity);
    }
   
}