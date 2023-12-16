using Abstractions.Repositories;
using Contracts.Logger;
using Contracts.User;
using Models.Operations;

namespace Application.Loggers;

public class UserOperationLogger : IUserOperationLogger
{
    private readonly IUserRepository _users;
    private readonly ICurrentUserService _user;
    private readonly IOperationRepository _operations;

    public UserOperationLogger(
        IUserRepository users,
        IOperationRepository operations,
        ICurrentUserService user)
    {
        _users = users;
        _operations = operations;
        _user = user;
    }

    public void LogRegistration(string username, OperationResult result)
    {
        string message = "SignUp";
        _operations.AddOperation(
            new Operation(
                username,
                " ",
                OperationType.AccountCreation,
                result,
                message)).ConfigureAwait(false);
    }

    public void LogLogin(string username, OperationResult result)
    {
        string message = "Log-In";
        _operations.AddOperation(
            new Operation(
                username,
                " ",
                OperationType.Login,
                result,
                message)).ConfigureAwait(false);
    }

    public void LogLogout()
    {
        if (_user.User is not null)
        {
            string message = "Logout";

            _operations.AddOperation(
                new Operation(
                    _user.User.Name,
                    " ",
                    OperationType.Logout,
                    OperationResult.Success,
                    message)).ConfigureAwait(false);
        }
    }
}