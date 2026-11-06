using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Interfaces;

public interface ITableRepository
{
    Task<Table?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Table>> GetAllAsync();

    Task AddAsync(Table table);
}