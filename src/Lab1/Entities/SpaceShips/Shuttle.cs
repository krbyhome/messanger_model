using Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Shuttle : SpaceShip
{
    public Shuttle()
        : base(
            engines: new IConsumingFuel[]
            {
                new CImpulseEngine(),
            },
            body: new Class1BodyEndurance())
    {
    }
}