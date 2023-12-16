using Contracts.User;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.OperationHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "History";

    public void Run()
    {
        IReadOnlyCollection<Operation?> history = _userService.ShowOperationHistory();

        AnsiConsole.WriteLine("List:\n");

        foreach (Operation? operation in history)
        {
            AnsiConsole.WriteLine(
                $"{operation?.UserId} - {operation?.AccountId} - {operation?.Message}\n");
        }

        AnsiConsole.WriteLine("\n");
    }
}