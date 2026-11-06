namespace IAWaiter.Application.DTOs.Branches;

public class CreateBranchRequest
{
    public Guid RestaurantId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}