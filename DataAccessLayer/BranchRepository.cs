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
    private readonly IMapper _mapperToDTO;
    private readonly IMapper _mapperToBranch;

    public BranchRepository(CredensContext context)
    {
        _context = context;
        _mapperToDTO = GenericMapperConfiguration<Branch, BranchDTO>.MapTo();
        _mapperToBranch = GenericMapperConfiguration<BranchDTO, Branch>.MapTo();
    }


    public virtual async Task AddAsync(BranchDTO entity)
    {
        await _context.Branches.AddAsync(_mapperToBranch.Map<Branch>(entity));
    }

    public virtual async Task DeleteAsync(BranchDTO entity)
    {
        _context.Branches.Remove(_mapperToBranch.Map<Branch>(entity));
    }

    public IQueryable<BranchDTO> FindAll()
    {
        return _context.Branches.ProjectTo<BranchDTO>(_mapperToDTO.ConfigurationProvider);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(BranchDTO entity)
    {
         _context.Entry(_mapperToBranch.Map<Branch>(entity)).State = EntityState.Modified;
    }
   
}