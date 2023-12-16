using Contracts.User;
using Spectre.Console;

namespace Console.Scenarios.Registration;

public class SignUpScenario : IScenario
{
    private readonly IUserService _userService;

    public SignUpScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Sign Up";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");

        SignUpResult result = _userService.Registration(username, password);

        string message = result switch
        {
            SignUpResult.Success => "Successful",
            SignUpResult.Failure => "Failure",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\n");
    }
}