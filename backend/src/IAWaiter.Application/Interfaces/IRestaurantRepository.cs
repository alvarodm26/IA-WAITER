using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Interfaces;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Restaurant>> GetAllAsync();

    Task AddAsync(Restaurant restaurant);

    Task UpdateAsync(Restaurant restaurant);

    Task DeleteAsync(Restaurant restaurant);
}