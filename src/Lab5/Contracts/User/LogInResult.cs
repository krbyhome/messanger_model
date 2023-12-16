namespace Contracts.User;

public abstract record LogInResult()
{
    public sealed record Success : LogInResult;

    public sealed record WrongPassword : LogInResult;

    public sealed record UserNotFound : LogInResult;
}