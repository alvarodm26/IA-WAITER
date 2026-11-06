using IAWaiter.Application.DTOs.Branches;
using IAWaiter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly BranchService _service;

    public BranchesController(BranchService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var branches =
            await _service.GetAllAsync();

        return Ok(branches);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateBranchRequest request)
    {
        var branch =
            await _service.CreateAsync(request);

        return Ok(branch);
    }
}