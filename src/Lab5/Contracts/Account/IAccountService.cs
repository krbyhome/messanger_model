using Models.Operations;

namespace Contracts.Account;

public interface IAccountService
{
    ICurrentAccountService AccountManager { get; }
    LogInResult CheckoutAccount(string id, string pinCode);
    OperationResult CreateAccount(string id, string pinCode);
    OperationResult WithdrawMoney(long money);
    OperationResult DepositMoney(long money);
    void LogoutBankAccount();
}