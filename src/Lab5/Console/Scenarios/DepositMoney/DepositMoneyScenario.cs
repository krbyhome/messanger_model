using Contracts.Account;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IAccountService _account;

    public DepositMoneyScenario(IAccountService account)
    {
        _account = account;
    }

    public string Name => "Deposit";

    public void Run()
    {
        long money = AnsiConsole.Ask<long>("Enter deposit: ");
        OperationResult result = _account.DepositMoney(money);

        string message = result switch
        {
            OperationResult.Success => "Successful",
            OperationResult.Fail => "Fail",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}