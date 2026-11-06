namespace IAWaiter.Application.DTOs.Categories;

public class CreateCategoryRequest
{
    public Guid RestaurantId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; }
        = string.Empty;
}