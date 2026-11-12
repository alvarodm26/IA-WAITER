using IAWaiter.Application.DTOs.Products;
using IAWaiter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
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
        CreateProductRequest request)
    {
        return Ok(await _service.CreateAsync(request));
    }
}