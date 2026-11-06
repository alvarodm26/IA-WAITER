using IAWaiter.Application.DTOs.Categories;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> CreateAsync(
        CreateCategoryRequest request)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            RestaurantId = request.RestaurantId,
            Name = request.Name,
            Description = request.Description,
            Active = true,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(category);

        return category;
    }

    public async Task<IReadOnlyList<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}