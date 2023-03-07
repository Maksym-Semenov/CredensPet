using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;

namespace DataAccessLayer.Repository;

public class BranchRepository : IRepository<BranchDTO>
{
    private readonly CredensContext _context;
    private readonly IMapper _mapper1;
    private readonly IMapper _mapper2;

    public BranchRepository(CredensContext context)
    {
        _context = context;
        _mapper1 = GenericMapperConfiguration<Branch, BranchDTO>.MapTo();
        _mapper2 = GenericMapperConfiguration<BranchDTO, Branch>.MapTo();
    }

    public void Add(BranchDTO entity)
    {
        var branchDTO = _mapper2.Map<Branch>(entity);
        _context.Branches.Add(branchDTO);
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public BranchDTO Find(params object[] keys)
    {
        var branchDTO = _mapper1.Map<BranchDTO>(_context.Branches.Find(keys));
        return branchDTO;
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _mapper1.Map<IEnumerable<BranchDTO>>(_context.Branches);
        return branchDTO;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(BranchDTO entity)
    {
         _mapper2.Map<Branch>(_context.Entry(entity).State = EntityState.Modified);
    }
    
}