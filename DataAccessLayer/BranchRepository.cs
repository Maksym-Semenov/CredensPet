﻿using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.EF;
using DataAccessLayer.Models;
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

    public IQueryable<BranchDTO> GetAllQ()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BranchDTO> GetAll()
    {
        var branch = _mapper1.Map<IEnumerable<BranchDTO>>(_context.Branches);
        return branch;
    }

    public void Add(BranchDTO entity)
    {
        var branch = _mapper2.Map<Branch>(entity);
        _context.Branches.Add(branch);
    }

    public void Update(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(BranchDTO entity)
    {
        throw new NotImplementedException();
    }

    public  Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task<BranchDTO> FindAsync(int? id)
    {
        throw new NotImplementedException();
    }
}