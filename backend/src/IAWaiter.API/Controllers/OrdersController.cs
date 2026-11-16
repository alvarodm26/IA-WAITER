using IAWaiter.Application.DTOs.Orders;
using IAWaiter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;

    public OrdersController(OrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateOrderRequest request)
    {
        return Ok(await _service.CreateAsync(request));
    }

    [HttpPut("{id}/preparing")]
    public async Task<IActionResult> Preparing(Guid id)
    {
        var order =
            await _service.MarkAsPreparing(id);

        return Ok(order);
    }

    [HttpPut("{id}/ready")]
    public async Task<IActionResult> Ready(Guid id)
    {
        var order =
            await _service.MarkAsReady(id);

        return Ok(order);
    }
}