namespace Contracts.Account;

public interface ICurrentAccountService
{
    Models.Account.Account? Account { get; set; }
}