namespace Models.Operations;

public record Operation(
    string UserId,
    string AccountId,
    OperationType Type,
    OperationResult Result,
    string Message);