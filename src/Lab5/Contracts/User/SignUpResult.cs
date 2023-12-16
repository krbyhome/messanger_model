namespace Contracts.User;

public abstract record SignUpResult()
{
    public sealed record Success : SignUpResult;

    public sealed record Failure : SignUpResult;
}