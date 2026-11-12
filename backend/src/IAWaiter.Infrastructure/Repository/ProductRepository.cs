using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;
using IAWaiter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        return await _context.Products
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();
    }
}
