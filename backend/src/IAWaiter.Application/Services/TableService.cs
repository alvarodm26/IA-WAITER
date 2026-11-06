using IAWaiter.Application.DTOs.Tables;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class TableService
{
    private readonly ITableRepository _repository;

    public TableService(ITableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Table> CreateAsync(
        CreateTableRequest request)
    {
        var table = new Table
        {
            Id = Guid.NewGuid(),
            BranchId = request.BranchId,
            Name = request.Name,
            Capacity = request.Capacity,
            Active = true,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(table);

        return table;
    }

    public async Task<IReadOnlyList<Table>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}