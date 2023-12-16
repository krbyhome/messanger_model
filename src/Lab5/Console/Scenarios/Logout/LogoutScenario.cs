using Contracts.User;
using Spectre.Console;

namespace Console.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";

    public void Run()
    {
        _userService.Logout();

        string message = "Logout";

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\n");
    }
}