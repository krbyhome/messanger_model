using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public sealed class CImpulseEngine : ImpulseEngine
{
    private const int Speed = 10;
    public CImpulseEngine()
        : base(20)
    {
    }

    public override EngineRunResult ConsumingFormulae(int distance, int resistance)
    {
        int time = distance * resistance / Speed;
        const int consumptionPerTimeUnit = 5;
        int consumption = consumptionPerTimeUnit * time;
        consumption += OnRunConsumption;
        return new EngineRunResult.Success(consumption, time, PlasmaFuelExchanger.Exchange(consumption));
    }
}