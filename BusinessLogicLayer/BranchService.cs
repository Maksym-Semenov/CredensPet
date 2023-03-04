using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.Models;

namespace BusinessLogicLayer;

public class BranchService : IService<BranchDTO>
{
    private readonly IRepository<BranchDTO> _branchRepository;
    public BranchService(IRepository<BranchDTO> branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _branchRepository.GetAll();
        return branchDTO;
    }

    public void Add(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(BranchDTO entity)
    {
        throw new NotImplementedException();
    }
}