using IAWaiter.Application.DTOs.Branches;
using IAWaiter.Application.Interfaces;
using IAWaiter.Domain.Entities;

namespace IAWaiter.Application.Services;

public class BranchService
{
    private readonly IBranchRepository _repository;

    public BranchService(IBranchRepository repository)
    {
        _repository = repository;
    }

    public async Task<Branch> CreateAsync(
        CreateBranchRequest request)
    {
        var branch = new Branch
        {
            Id = Guid.NewGuid(),
            RestaurantId = request.RestaurantId,
            Name = request.Name,
            Address = request.Address,
            Phone = request.Phone,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(branch);

        return branch;
    }

    public async Task<IReadOnlyList<Branch>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}