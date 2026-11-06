namespace IAWaiter.Application.DTOs.Restaurants;

public class CreateRestaurantRequest
{
    public string Name { get; set; } = string.Empty;

    public string BusinessName { get; set; } = string.Empty;

    public string Ruc { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}