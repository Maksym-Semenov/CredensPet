using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class BranchRepository : IRepository<BranchDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapper;
    public BranchRepository(CredensContext context)
    {
        _context = context;
        _mapper = GenericMapperConfiguration<Branch, BranchDTO>.MapTo();
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branch = _mapper.Map<IEnumerable<BranchDTO>>(_context.Branches);
        return branch;
    }

    //public IQueryable<Project> GetAll()
    //{
    //    return _context.Projects.AsQueryable();
    //}

    public void Add(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }
   
}