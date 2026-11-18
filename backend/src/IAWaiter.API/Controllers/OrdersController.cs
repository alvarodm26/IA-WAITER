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

    [HttpPut("{id}/delivered")]
    public async Task<IActionResult> Delivered(Guid id)
    {
        var order =
            await _service.MarkAsDelivered(id);

        return Ok(order);
    }

    [HttpPut("{id}/paid")]
    public async Task<IActionResult> Paid(Guid id)
    {
        var order =
            await _service.MarkAsPaid(id);

        return Ok(order);
    }

    [HttpPut("{id}/cancelled")]
    public async Task<IActionResult> Cancelled(Guid id)
    {
        var order =
            await _service.MarkAsCancelled(id);

        return Ok(order);
    }

    [HttpGet("version")]
    public IActionResult Version()
    {
        return Ok("v2");
    }

    [HttpGet("kitchen")]
    public async Task<IActionResult> Kitchen()
    {
        var orders = await _service.GetAllAsync();

        var result = orders
            .Where(x =>
                x.Status == "Pending" ||
                x.Status == "Preparing")
            .Select(x => new
            {
                x.Id,
                x.OrderNumber,
                x.Status,
                x.Total,
                x.CreatedAt
            })
            .ToList();

        return Ok(result);
    }
}