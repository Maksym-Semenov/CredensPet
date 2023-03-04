using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;

namespace BusinessLogicLayer;

public class ContactService : IService<ContactDTO>
{
    private readonly IRepository<ContactDTO> _branchRepository;
    public ContactService(IRepository<ContactDTO> branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        var contactDTO = _branchRepository.GetAll();
        return contactDTO;
    }

    public void Add(ContactDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ContactDTO entity)
    {
        throw new NotImplementedException();
    }
   

    public void Update(ContactDTO entity)
    {
        throw new NotImplementedException();
    }
}