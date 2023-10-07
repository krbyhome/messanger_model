using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

public class OmegaJumpingEngine : JumpingEngine
{
    private const int Distance = 10000;
    public OmegaJumpingEngine()
        : base(Distance)
    {
    }

    public override EngineRunResult ConsumingFormulae(int distance, int resistance)
    {
        const int distancePerFuelUnit = 30;
        const int speed = 80;
        int consumption = (distance * int.Log2(distance)) / distancePerFuelUnit;
        int time = distance / speed;
        return new EngineRunResult.Success(consumption, time, GravityMatterExchanger.Exchange(consumption));
    }
}