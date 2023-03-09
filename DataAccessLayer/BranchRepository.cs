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
        //_dbSet = context.Set<Branch>();
    }

    public async Task AddAsync(BranchDTO entity)
    {
        await _context.Branches.AddAsync(_mapperToBranch.Map<Branch>(entity));
    }

    public async Task DeleteAsync(BranchDTO entity)
    {
        _context.Branches.Remove(_mapperToBranch.Map<Branch>(entity));
    }

    public BranchDTO Find(params object[] keys)
    {
        return _mapperToDTO.Map<BranchDTO>(_context.Branches.Find(keys));
    }

    public IQueryable<BranchDTO> FindAll()
    {
        return _context.Branches.ProjectTo<BranchDTO>(_mapperToDTO.ConfigurationProvider);
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

    public async Task UpdateAsync(BranchDTO entity)
    {
        var branch = _mapperToBranch.Map<Branch>(entity);
         _context.Entry(branch).State = EntityState.Modified;
    }
   
}