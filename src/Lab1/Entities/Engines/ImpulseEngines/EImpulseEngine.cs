using System;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public class EImpulseEngine : ImpulseEngine
{
    public EImpulseEngine()
        : base(40)
    {
    }

    public override EngineRunResult ConsumingFormulae(int distance, int resistance)
    {
        int time = int.Log2(distance + resistance);
        double consumptionPerTimeUnit = Math.Pow(2, time) / time;
        int consumption = (int)consumptionPerTimeUnit * time;
        consumption += OnRunConsumption;
        return new EngineRunResult.Success(consumption, time, PlasmaFuelExchanger.Exchange(consumption));
    }
}