using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class PhotonicDeflector : Deflector
{
    protected PhotonicDeflector(int health)
        : base(health)
    {
        FlashReflection = new FlashDamage(3);
    }

    public Damage FlashReflection { get; set; }

    public override DamageResult TakeDamage(Damage damageTaken)
    {
        if (damageTaken is not FlashDamage)
        {
            return base.TakeDamage(damageTaken);
        }

        FlashReflection.Subtract(damageTaken);
        if (FlashReflection.Negative())
        {
            return new DamageResult.CrewDead();
        }

        return new DamageResult.SpaceShipIsOk();
    }
}