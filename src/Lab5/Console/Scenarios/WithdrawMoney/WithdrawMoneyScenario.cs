using Contracts.Account;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _account;

    public WithdrawMoneyScenario(IAccountService account)
    {
        _account = account;
    }

    public string Name => "Withdraw";

    public void Run()
    {
        long money = AnsiConsole.Ask<long>("Enter sum: ");
        OperationResult result = _account.WithdrawMoney(money);

        string message = result switch
        {
            OperationResult.Success => "Successful",
            OperationResult.Fail => "Fail",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}