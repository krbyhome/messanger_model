using Abstractions.Repositories;
using Application.Loggers;
using Contracts.Account;
using Contracts.Logger;
using Contracts.User;
using Models.Operations;
using LogInResult = Contracts.Account.LogInResult;

namespace Application.Account;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationRepository _operationRepository;
    private readonly ICurrentUserService _currentUserManager;
    private readonly IAccountOperationLogger _operationLogger;

    public AccountService(
        IAccountRepository accountRepository,
        IOperationRepository operationRepository,
        ICurrentUserService userManager,
        ICurrentAccountService accountManager)
    {
        _currentUserManager = userManager;
        _operationRepository = operationRepository;
        AccountManager = accountManager;
        _accountRepository = accountRepository;
        _operationLogger = new AccountOperationLogger(
            accountRepository,
            operationRepository,
            userManager,
            accountManager);
    }

    public ICurrentAccountService AccountManager { get; set; }

    public LogInResult CheckoutAccount(string id, string pinCode)
    {
        Models.Account.Account? account = _accountRepository.FindAccountById(id).Result;

        if (account == null
            || account.UserId != _currentUserManager.User?.Id)
        {
            _operationLogger.LogLoginEvent(id, OperationResult.Fail);
            return new LogInResult.NotFound();
        }

        if (account.PinCode != pinCode)
        {
            _operationLogger.LogLoginEvent(id, OperationResult.Fail);
            return new LogInResult.WrongPinCode();
        }

        AccountManager.Account = account;
        _operationLogger.LogLoginEvent(id, OperationResult.Success);

        return new LogInResult.Success();
    }

    public OperationResult CreateAccount(string id, string pinCode)
    {
        if (_currentUserManager.User is not null)
        {
            Task.Run(async () =>
            {
                await _accountRepository.CreateAccount(
                    new Models.Account.Account(
                        0,
                        _currentUserManager.User.Id,
                        id,
                        0,
                        pinCode)).ConfigureAwait(false);

                _operationLogger.LogAccountCreation(id);
            }).GetAwaiter().GetResult();
        }

        return OperationResult.Success;
    }

    public OperationResult WithdrawMoney(long money)
    {
        if (_currentUserManager.User is null || AccountManager.Account is null)
        {
            return OperationResult.Fail;
        }

        if (AccountManager.Account.Balance < money)
        {
            _operationLogger.LogWithdraw(money, OperationResult.Fail);
            return OperationResult.Fail;
        }

        AccountManager.Account = AccountManager.Account with { Balance = AccountManager.Account.Balance - money };

        Task.Run(async () =>
        {
            await _accountRepository.ChangeBalance(
                    AccountManager.Account.Name,
                    AccountManager.Account.Balance)
                .ConfigureAwait(false);
        }).GetAwaiter().GetResult();

        return OperationResult.Success;
    }

    public OperationResult DepositMoney(long money)
    {
        if (_currentUserManager.User is null || AccountManager.Account is null)
        {
            return OperationResult.Fail;
        }

        AccountManager.Account = AccountManager.Account with { Balance = AccountManager.Account.Balance + money };

        Task.Run(async () =>
        {
            await _accountRepository.ChangeBalance(
                AccountManager.Account.Name,
                AccountManager.Account.Balance).ConfigureAwait(false);

            _operationLogger.LogRefill(money, OperationResult.Success);
        }).GetAwaiter().GetResult();

        return OperationResult.Success;
    }

    public void LogoutBankAccount()
    {
        if (_currentUserManager.User is not null
            && AccountManager.Account is not null)
        {
            _operationLogger.LogLogoutEvent(AccountManager.Account.Name);
        }

        AccountManager.Account = null;
    }
}