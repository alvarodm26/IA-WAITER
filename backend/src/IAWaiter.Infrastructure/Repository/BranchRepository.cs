using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;
using IAWaiter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.Infrastructure.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly AppDbContext _context;

    public BranchRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Branch?> GetByIdAsync(Guid id)
    {
        return await _context.Branches
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Branch>> GetAllAsync()
    {
        return await _context.Branches
            .ToListAsync();
    }

    public async Task AddAsync(Branch branch)
    {
        await _context.Branches.AddAsync(branch);

        await _context.SaveChangesAsync();
    }
}