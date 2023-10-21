using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

public class NitrineParticleNebulae : IEnviroment
{
    public NitrineParticleNebulae(IReadOnlyCollection<INitrineParticleNebulaeObstacle> obstacles)
    {
        Obstacles = obstacles;
        EngineRequired = EngineType.Impulse;
        Resistance = 10;
    }

    public IReadOnlyCollection<IHittable> Obstacles { get; }
    public EngineType EngineRequired { get; }
    public int Resistance { get; }
}