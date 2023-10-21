using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

public abstract class JumpingEngine : IConsumingFuel
{
    protected JumpingEngine(int range)
    {
        Range = range;
        Type = EngineType.Jumping;
    }

    public EngineType Type { get; protected set; }
    private int Range { get; init; }

    public EngineRunResult ConsumeFuel(Section section)
    {
        if (section.Enviroment.EngineRequired != Type)
        {
            return new EngineRunResult.EngineDoNotFit();
        }

        EngineRunResult totalConsumption = ConsumingFormulae(section.Distance, section.Enviroment.Resistance);
        return Range < section.Distance ?
            new EngineRunResult.DistanceLimitReached(Range) : totalConsumption;
    }

    public abstract EngineRunResult ConsumingFormulae(int distance, int resistance);
}