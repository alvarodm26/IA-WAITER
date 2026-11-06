namespace IAWaiter.Application.DTOs.Tables;

public class CreateTableRequest
{
    public Guid BranchId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; }
}