using Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Vaclas : SpaceShip
{
    public Vaclas(PhotonicModifier modificator = PhotonicModifier.False)
        : base(
            engines: new IConsumingFuel[]
            {
                new EImpulseEngine(),
                new GammaJumpingEngine(),
            },
            body: new Class2BodyEndurance(),
            deflector: new Class1Deflector())
    {
            Deflector = modificator switch
            {
                PhotonicModifier.True => new Class1PhotonicDeflector(),
                _ => Deflector,
            };
    }
}