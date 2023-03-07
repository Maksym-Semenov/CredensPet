using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly DbSet<Branch> _dbSet;
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToBranch;

    public BranchRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<Branch, BranchDTO>.MapTo();
        _mapperToBranch = GenericMapperConfiguration<BranchDTO, Branch>.MapTo();
        _dbSet = context.Set<Branch>();
    }

    public void Add(BranchDTO entity)
    {
        var branchDTO = _mapperToBranch.Map<Branch>(entity);
        _context.Branches.Add(branchDTO);
    }

    public void Delete(BranchDTO entity)
    {
        _dbSet.Remove(_mapperToBranch.Map<Branch>(entity));
    }

    public BranchDTO Find(params object[] keys)
    {
        return _mapperToDTO.Map<BranchDTO>(_context.Branches.Find(keys));
    }

    public IQueryable<BranchDTO> FindAll()
    {
        return _dbSet.ProjectTo<BranchDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task<BranchDTO> FindAsync(params object[] keys)
    {
        return _mapperToDTO.Map<BranchDTO>(_context.Branches.FindAsync(keys));
    }

    public virtual async Task<BranchDTO> FirstOrDefault(params object[] keys)
    {
        return _mapperToDTO.Map<BranchDTO>(_context.Branches.FindAsync(keys));
        //return branchDTO;
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branchDTO = _mapperToDTO.Map<IEnumerable<BranchDTO>>(_context.Branches);
        return branchDTO;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Update(BranchDTO entity)
    {
        var branch = _mapperToBranch.Map<Branch>(entity);
         _context.Entry(branch).State = EntityState.Modified;
    }
   
}