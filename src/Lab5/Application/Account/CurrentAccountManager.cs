using Contracts.Account;

namespace Application.Account;

public class CurrentAccountManager : ICurrentAccountService
{
    public Models.Account.Account? Account { get; set; }
}