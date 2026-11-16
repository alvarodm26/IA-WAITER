using IAWaiter.Application.DTOs.Orders;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    private readonly IProductRepository _productRepository;

    public OrderService(
        IOrderRepository repository,
        IProductRepository productRepository)
    {
        _repository = repository;
        _productRepository = productRepository;
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

        decimal total = 0;

        foreach (var item in request.Items)
        {
            var product = await _productRepository
                .GetByIdAsync(item.ProductId);

            if (product == null)
            {
                throw new Exception(
                    $"Product {item.ProductId} not found");
            }

            order.Items.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });

            total += product.Price * item.Quantity;
        }

        order.Total = total;

        await _repository.AddAsync(order);

        return order;
    }

    public async Task<IReadOnlyList<Order>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Order?> MarkAsPreparing(Guid id)
    {
        var order = (await _repository.GetAllAsync())
            .FirstOrDefault(x => x.Id == id);

        if (order == null)
            return null;

        order.Status = "Preparing";

        await _repository.UpdateAsync(order);

        return order;
    }

    public async Task<Order?> MarkAsReady(Guid id)
    {
        var order = (await _repository.GetAllAsync())
            .FirstOrDefault(x => x.Id == id);

        if (order == null)
            return null;

        order.Status = "Ready";

        await _repository.UpdateAsync(order);

        return order;
    }
}