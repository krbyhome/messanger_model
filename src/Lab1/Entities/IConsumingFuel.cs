using Itmo.ObjectOrientedProgramming.Lab1.Common;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IConsumingFuel
{
    public EngineRunResult ConsumeFuel(Section section);
    protected EngineRunResult ConsumingFormulae(int distance, int resistance);
}