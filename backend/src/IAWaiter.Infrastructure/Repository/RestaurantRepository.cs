using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;
using IAWaiter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.Infrastructure.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly AppDbContext _context;

    public RestaurantRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Restaurant?> GetByIdAsync(Guid id)
    {
        return await _context.Restaurants
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Restaurant>> GetAllAsync()
    {
        return await _context.Restaurants
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task AddAsync(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Restaurant restaurant)
    {
        _context.Restaurants.Remove(restaurant);

        await _context.SaveChangesAsync();
    }
}