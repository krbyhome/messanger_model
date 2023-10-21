using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

public sealed class DenseNebulae : IEnviroment
{
    public DenseNebulae(IReadOnlyCollection<ISubspaceThreadObstacle> obstacles)
    {
        Obstacles = obstacles;
        EngineRequired = EngineType.Jumping;
        Resistance = 1;
    }

    public IReadOnlyCollection<IHittable> Obstacles { get; }
    public EngineType EngineRequired { get; }
    public int Resistance { get; }
}