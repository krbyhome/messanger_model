using Contracts.Account;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CreateAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Create new account";

    public void Run()
    {
        string? name = AnsiConsole.Ask<string>("Name your account");
        string pinCode = AnsiConsole.Ask<string>("Enter password: ");

        OperationResult result = _accountService.CreateAccount(name, pinCode);

        string message = result switch
        {
            OperationResult.Success => "Success",
            OperationResult.Fail => "Failure",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\n");
    }
}