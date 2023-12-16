using Contracts.Account;
using Models.Account;
using Spectre.Console;

namespace Console.Scenarios.Balance;

public class ShowBalanceScenario : IScenario
{
    private readonly IAccountService _account;

    public ShowBalanceScenario(IAccountService account)
    {
        _account = account;
    }

    public string Name => "Show balance";

    public void Run()
    {
        Account? bankAccount = _account.AccountManager.Account;

        long? balance = bankAccount?.Balance;

        AnsiConsole.WriteLine($"Total: {balance}\n");
    }
}