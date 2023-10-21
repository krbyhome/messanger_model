using Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpingEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Avgur : SpaceShip
{
    public Avgur(PhotonicModifier modificator = PhotonicModifier.False)
        : base(
            engines: new IConsumingFuel[]
            {
                new EImpulseEngine(),
                new AlphaJumpingEngine(),
            },
            body: new Class3BodyEndurance(),
            deflector: new Class3Deflector())
    {
            Deflector = modificator switch
            {
                PhotonicModifier.True => new Class3PhotonicDeflector(),
                _ => Deflector,
            };
    }
}