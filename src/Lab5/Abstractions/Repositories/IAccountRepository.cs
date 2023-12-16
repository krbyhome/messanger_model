using Models.Account;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
    Task<Account?> FindAccountById(string? id);
    Task CreateAccount(Account account);
    Task ChangeBalance(string? id, long money);
}