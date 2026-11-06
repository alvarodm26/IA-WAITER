using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Interfaces;

public interface IBranchRepository
{
    Task<Branch?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Branch>> GetAllAsync();

    Task AddAsync(Branch branch);
}