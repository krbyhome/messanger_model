using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class ShipRunnerService : IShipRunnerService
{
    public TravelResult Run(SpaceShip ship, Route route)
    {
        int time = 0;
        int fuel = 0;
        int cost = 0;
        foreach (Section section in route.Sections)
        {
            (DamageResult? damageResult, EngineRunResult? engineRunResult) = ship.Travel(section);
            switch (damageResult)
            {
                case DamageResult.SpaceShipDestroyed:
                    return new TravelResult.SpaceShipDestroyed();
                case DamageResult.CrewDead:
                    return new TravelResult.CrewDead();
            }

            switch (engineRunResult)
            {
                case EngineRunResult.DistanceLimitReached limit:
                    return new TravelResult.LostInSpace(limit.Limit);
                case EngineRunResult.EngineDoNotFit:
                    return new TravelResult.NoRequiredEngine();
                case EngineRunResult.Success consumes:
                    time += consumes.Time;
                    fuel += consumes.Consumption;
                    cost += consumes.Cost;
                    continue;
            }
        }

        return new TravelResult.Success(time, fuel, cost);
    }
}