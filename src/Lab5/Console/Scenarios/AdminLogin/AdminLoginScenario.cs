using Contracts.User;
using Spectre.Console;

namespace Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public AdminLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Admin Mode";

    public void Run()
    {
        string login = AnsiConsole.Ask<string>("Enter username");
        string password = AnsiConsole.Ask<string>("Enter admin password");

        LogInResult result = _userService.AdminLogin(login, password);

        string message = result switch
        {
            LogInResult.Success => "Admin mode",
            LogInResult.WrongPassword => "Wrong Password",
            LogInResult.UserNotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\n");
    }
}