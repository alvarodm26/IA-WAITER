using IAWaiter.Application.DTOs.Restaurants;
using IAWaiter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly RestaurantService _restaurantService;

    public RestaurantsController(
        RestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants =
            await _restaurantService.GetAllAsync();

        return Ok(restaurants);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateRestaurantRequest request)
    {
        var restaurant =
            await _restaurantService.CreateAsync(request);

        return Ok(restaurant);
    }
}