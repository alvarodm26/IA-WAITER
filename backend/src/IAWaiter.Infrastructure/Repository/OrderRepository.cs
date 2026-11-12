using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;
using IAWaiter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(x => x.Items)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);

        await _context.SaveChangesAsync();
    }
}