using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

public class AlphaJumpingEngine : JumpingEngine
{
    private const int Distance = 1000;
    public AlphaJumpingEngine()
        : base(Distance)
    {
    }

    public override EngineRunResult ConsumingFormulae(int distance, int resistance)
    {
        const int distancePerFuelUnit = 10;
        const int speed = 20;
        int consumption = distance / distancePerFuelUnit;
        int time = distance / speed;
        return new EngineRunResult.Success(consumption, time, GravityMatterExchanger.Exchange(consumption));
    }
}