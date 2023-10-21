using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

public class GammaJumpingEngine : JumpingEngine
{
    private const int Distance = 100000;
    public GammaJumpingEngine()
        : base(Distance)
    {
    }

    public override EngineRunResult ConsumingFormulae(int distance, int resistance)
    {
        const int distancePerFuelUnit = 100;
        const int speed = 400;
        int consumption = (distance * distance) / distancePerFuelUnit;
        int time = distance / speed;
        return new EngineRunResult.Success(consumption, time, GravityMatterExchanger.Exchange(consumption));
    }
}