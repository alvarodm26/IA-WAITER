using IAWaiter.Application.DTOs.Tables;
using IAWaiter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TablesController : ControllerBase
{
    private readonly TableService _service;

    public TablesController(TableService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tables = await _service.GetAllAsync();

        return Ok(tables);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTableRequest request)
    {
        var table = await _service.CreateAsync(request);

        return Ok(table);
    }
}