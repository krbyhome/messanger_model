using Contracts.Account;
using Spectre.Console;

namespace Console.Scenarios.CheckoutAccount;

public class CheckOutAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckOutAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Login Bank account";

    public void Run()
    {
        string accountNumber = AnsiConsole.Ask<string>("Enter account name");
        string pinCode = AnsiConsole.Ask<string>("Enter password");

        LogInResult result = _accountService.CheckoutAccount(accountNumber, pinCode);

        string message = result switch
        {
            LogInResult.Success => "Successful checkout account",
            LogInResult.WrongPinCode => "wrong password",
            LogInResult.NotFound => "Account doesn't exist",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}