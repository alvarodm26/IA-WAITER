using IAWaiter.Application.DTOs.Restaurants;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class RestaurantService
{
    private readonly IRestaurantRepository _repository;

    public RestaurantService(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Restaurant> CreateAsync(CreateRestaurantRequest request)
    {
        var restaurant = new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            BusinessName = request.BusinessName,
            Ruc = request.Ruc,
            Email = request.Email,
            Phone = request.Phone,
            Active = true,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(restaurant);

        return restaurant;
    }

    public async Task<IReadOnlyList<Restaurant>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
