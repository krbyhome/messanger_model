using Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Stella : SpaceShip
{
    public Stella(PhotonicModifier modificator = PhotonicModifier.False)
        : base(
            engines: new IConsumingFuel[]
            {
                new CImpulseEngine(),
                new OmegaJumpingEngine(),
            },
            body: new Class1BodyEndurance(),
            deflector: new Class1Deflector())
    {
            Deflector = modificator switch
            {
                PhotonicModifier.True => new Class1PhotonicDeflector(),
                _ => Deflector,
            };
    }
}