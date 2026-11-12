namespace IAWaiter.Application.DTOs.Orders;

public class CreateOrderRequest
{
    public Guid TableId { get; set; }

    public List<CreateOrderItemRequest> Items { get; set; }
        = new();
}
