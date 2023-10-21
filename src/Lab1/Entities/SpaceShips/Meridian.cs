using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Meridian : SpaceShip, IAntiNitrineModified
{
    public Meridian(PhotonicModifier modificator = PhotonicModifier.False)
        : base(
            engines: new IConsumingFuel[]
            {
                new EImpulseEngine(),
            },
            body: new Class2BodyEndurance(),
            deflector: new Class2Deflector())
    {
            Deflector = modificator switch
            {
                PhotonicModifier.True => new Class2PhotonicDeflector(),
                _ => Deflector,
            };
    }

    public DamageResult ScareCosmoWhales(Damage damage)
    {
        return new DamageResult.SpaceShipIsOk();
    }

    public override DamageResult TakeDamage(Damage damageTaken)
    {
        return damageTaken is CriticalDamage ?
            ScareCosmoWhales(damageTaken) : base.TakeDamage(damageTaken);
    }
}