using IAWaiter.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IAWaiter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly AppDbContext _context;

    public MenuController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("table/{tableId}")]
    public async Task<IActionResult> GetMenu(
        Guid tableId)
    {
        var table = await _context.Tables
            .Include(x => x.Branch)
            .FirstOrDefaultAsync(x => x.Id == tableId);

        if (table == null)
            return NotFound();

        var categories = await _context.Categories
            .Include(x => x.Restaurant)
            .ToListAsync();

        var products = await _context.Products
            .ToListAsync();

        return Ok(new
        {
            Table = table.Name,

            Categories = categories.Select(c => new
            {
                c.Id,
                c.Name,

                Products = products
                    .Where(p =>
                        p.CategoryId == c.Id)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Description,
                        p.Price
                    })
            })
        });
    }
}