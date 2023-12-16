using Models.Operations;

namespace Contracts.Logger;

public interface IUserOperationLogger
{
    void LogRegistration(string username, OperationResult result);
    void LogLogin(string username, OperationResult result);
    void LogLogout();
}