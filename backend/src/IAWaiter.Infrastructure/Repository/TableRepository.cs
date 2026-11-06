using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;
using IAWaiter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.Infrastructure.Repositories;

public class TableRepository : ITableRepository
{
    private readonly AppDbContext _context;

    public TableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Table?> GetByIdAsync(Guid id)
    {
        return await _context.Tables
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Table>> GetAllAsync()
    {
        return await _context.Tables.ToListAsync();
    }

    public async Task AddAsync(Table table)
    {
        await _context.Tables.AddAsync(table);

        await _context.SaveChangesAsync();
    }
}