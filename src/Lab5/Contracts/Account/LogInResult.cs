namespace Contracts.Account;

public abstract record LogInResult()
{
    public sealed record Success : LogInResult;

    public sealed record WrongPinCode : LogInResult;

    public sealed record NotFound : LogInResult;
}