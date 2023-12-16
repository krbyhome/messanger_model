using Models.Operations;

namespace Abstractions.Repositories;

public interface IOperationRepository
{
    Task AddOperation(Operation? operation);
    Task<List<Operation?>> GetOperations(string userId);
}