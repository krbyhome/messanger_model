namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract record EngineRunResult
{
    internal sealed record Success(int Consumption, int Time, int Cost) : EngineRunResult;
    internal sealed record DistanceLimitReached(int Limit) : EngineRunResult;

    internal sealed record EngineDoNotFit : EngineRunResult;
}