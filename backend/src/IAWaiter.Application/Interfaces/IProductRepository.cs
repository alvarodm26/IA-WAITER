using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Product>> GetAllAsync();

    Task AddAsync(Product product);
}
