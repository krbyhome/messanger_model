namespace Itmo.ObjectOrientedProgramming.Lab1.Common;

public abstract record DamageResult
{
    internal sealed record DeflectorBroken : DamageResult;

    internal sealed record SpaceShipIsOk : DamageResult;

    internal sealed record CrewDead : DamageResult;
    internal sealed record SpaceShipDestroyed : DamageResult;
}