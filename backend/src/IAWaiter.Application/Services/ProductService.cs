using IAWaiter.Application.DTOs.Products;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> CreateAsync(
        CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            CategoryId = request.CategoryId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ImageUrl = request.ImageUrl,
            Active = true,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(product);

        return product;
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}