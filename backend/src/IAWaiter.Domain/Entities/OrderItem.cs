namespace IAWaiter.Domain.Entities;
using System.Text.Json.Serialization;

public class OrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    [JsonIgnore]
    public Order Order { get; set; } = null!;

    [JsonIgnore]
    public Product Product { get; set; } = null!;
}
