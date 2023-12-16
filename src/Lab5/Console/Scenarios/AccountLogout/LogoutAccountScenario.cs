using Contracts.Account;
using Spectre.Console;

namespace Console.Scenarios.AccountLogout;

public class LogoutAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LogoutAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Logout Account";

    public void Run()
    {
        _accountService.LogoutBankAccount();
        string message = "Logout";

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\n");
    }
}