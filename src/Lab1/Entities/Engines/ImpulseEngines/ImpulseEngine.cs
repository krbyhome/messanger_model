using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public abstract class ImpulseEngine : IConsumingFuel
{
    protected ImpulseEngine(int onRunConsumption)
    {
        OnRunConsumption = onRunConsumption;
        Type = EngineType.Impulse;
    }

    public int OnRunConsumption { get; }
    public EngineType Type { get; }
    public EngineRunResult ConsumeFuel(Section section)
    {
        if (section.Enviroment.EngineRequired != Type)
        {
            return new EngineRunResult.EngineDoNotFit();
        }

        EngineRunResult consumption = ConsumingFormulae(section.Distance, section.Enviroment.Resistance);
        return consumption;
    }

    public abstract EngineRunResult ConsumingFormulae(int distance, int resistance);
}