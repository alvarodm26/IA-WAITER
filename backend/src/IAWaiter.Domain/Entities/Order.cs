namespace IAWaiter.Domain.Entities;
using System.Text.Json.Serialization;

public class Order
{
    public Guid Id { get; set; }

    public Guid TableId { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public string Status { get; set; } = "Pending";

    public decimal Total { get; set; }

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

    [JsonIgnore]
    public Table Table { get; set; } = null!;

    public ICollection<OrderItem> Items { get; set; }
        = new List<OrderItem>();
}