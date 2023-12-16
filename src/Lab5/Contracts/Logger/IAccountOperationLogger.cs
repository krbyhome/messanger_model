using Models.Operations;

namespace Contracts.Logger;

public interface IAccountOperationLogger
{
    void LogLoginEvent(string id, OperationResult result);
    void LogLogoutEvent(string id);
    void LogAccountCreation(string accountName);
    void LogWithdraw(long money, OperationResult result);
    void LogRefill(long money, OperationResult result);
}