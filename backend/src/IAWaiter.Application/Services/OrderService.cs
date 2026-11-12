using IAWaiter.Application.DTOs.Orders;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> CreateAsync(
        CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            TableId = request.TableId,
            OrderNumber = $"ORD-{DateTime.UtcNow.Ticks}",
            Status = "Pending",
            Total = 0,
            CreatedAt = DateTime.UtcNow
        };

        foreach (var item in request.Items)
        {
            order.Items.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = 0
            });
        }

        await _repository.AddAsync(order);

        return order;
    }

    public async Task<IReadOnlyList<Order>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}