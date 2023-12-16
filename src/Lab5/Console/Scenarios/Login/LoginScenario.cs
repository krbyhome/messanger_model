using Contracts.User;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");

        Contracts.User.LogInResult result = _userService.Login(username, password);

        string message = result switch
        {
            Contracts.User.LogInResult.Success => "Successful login",
            Contracts.User.LogInResult.UserNotFound => "User not found",
            Contracts.User.LogInResult.WrongPassword => "Wrong password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\n");
    }
}