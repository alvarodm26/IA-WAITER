using IAWaiter.Application.DTOs.Categories;
using IAWaiter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _service;

    public CategoriesController(CategoryService service)
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
        CreateCategoryRequest request)
    {
        return Ok(await _service.CreateAsync(request));
    }
}