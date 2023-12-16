using Abstractions.Repositories;
using Contracts.Account;
using Contracts.Logger;
using Contracts.User;
using Models.Operations;

namespace Application.Loggers;

public class AccountOperationLogger : IAccountOperationLogger
{
    private readonly IAccountRepository _accounts;
    private readonly IOperationRepository _operations;
    private readonly ICurrentUserService _user;
    private readonly ICurrentAccountService _account;
    public AccountOperationLogger(
        IAccountRepository accounts,
        IOperationRepository operations,
        ICurrentUserService user,
        ICurrentAccountService account)
    {
        _accounts = accounts;
        _operations = operations;
        _user = user;
        _account = account;
    }

    public void LogLoginEvent(string id, OperationResult result)
    {
        if (_user.User != null)
        {
            string message = $"Login bank account {id}";
            _operations.AddOperation(
                new Operation(
                    _user.User.Name,
                    id,
                    OperationType.Login,
                    result,
                    message)).ConfigureAwait(false);
        }
    }

    public void LogLogoutEvent(string id)
    {
        if (_user.User is not null && _account.Account is not null)
        {
            string message = $"logout account {_account.Account.Name}";

            _operations.AddOperation(
                new Operation(
                    _user.User.Name,
                    _account.Account.Name,
                    OperationType.Logout,
                    OperationResult.Success,
                    message)).ConfigureAwait(false);
        }
    }

    public void LogAccountCreation(string accountName)
    {
        if (_user.User != null)
        {
            string message = $"{_user.User.Name} created account {accountName}";

            _operations.AddOperation(new Operation(
                _user.User.Name,
                accountName,
                OperationType.AccountCreation,
                OperationResult.Success,
                message)).ConfigureAwait(false);
        }
    }

    public void LogWithdraw(long money, OperationResult result)
    {
        string message = $"-{money}$";
        if (_user.User is null || _account.Account is null)
            return;

        var operation = new Operation(
            _user.User.Name,
            _account.Account.Name,
            OperationType.Withdraw,
            result,
            message);

        _operations.AddOperation(operation).ConfigureAwait(false);
    }

    public void LogRefill(long money, OperationResult result)
    {
        string message = $"+{money}$";
        if (_user.User is null || _account.Account is null)
            return;

        var operation = new Operation(
            _user.User.Name,
            _account.Account.Name,
            OperationType.Withdraw,
            result,
            message);

        _operations.AddOperation(operation).ConfigureAwait(false);
    }
}