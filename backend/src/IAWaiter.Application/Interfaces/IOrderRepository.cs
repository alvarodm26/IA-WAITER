using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Interfaces;

public interface IOrderRepository
{
    Task<IReadOnlyList<Order>> GetAllAsync();

    Task AddAsync(Order order);
}