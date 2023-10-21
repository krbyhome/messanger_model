using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

public interface IEnviroment
{
    public IReadOnlyCollection<IHittable> Obstacles { get; }
    public EngineType EngineRequired { get; }
    public int Resistance { get; }
}