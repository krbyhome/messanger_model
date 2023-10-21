namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract record TravelResult
{
    internal record Success(int Time, int Fuel, int Cost) : TravelResult;

    internal record LostInSpace(int Limit) : TravelResult;

    internal record SpaceShipDestroyed : TravelResult;

    internal record NoRequiredEngine : TravelResult;

    internal record CrewDead : TravelResult;
}