using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

public sealed class DefaultSpace : IEnviroment
{
    public DefaultSpace(IReadOnlyCollection<IDefaultSpaceObstacle> obstacles)
    {
        Obstacles = obstacles;
        EngineRequired = EngineType.Impulse;
        Resistance = 1;
    }

    public IReadOnlyCollection<IHittable> Obstacles { get; }
    public EngineType EngineRequired { get; }
    public int Resistance { get; }
}