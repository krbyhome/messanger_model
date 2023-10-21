using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector : IDamageable
{
    protected Deflector(int health)
    {
        HealthPointBalance = new PhysicalDamage(health);
    }

    public bool IsComplete => HealthPointBalance.Positive();
    public Damage HealthPointBalance { get; set; }

    public virtual DamageResult TakeDamage(Damage damageTaken)
    {
        switch (damageTaken)
        {
            case FlashDamage:
                return new DamageResult.CrewDead();
            case CriticalDamage:
                HealthPointBalance.Subtract(damageTaken);
                break;
            case not PhysicalDamage:
                throw new ShipException("Unknown type of Damage");
        }

        if (HealthPointBalance.Positive())
        {
            return new DamageResult.SpaceShipIsOk();
        }

        if (HealthPointBalance.Zero())
        {
            return new DamageResult.DeflectorBroken();
        }

        return new DamageResult.SpaceShipDestroyed();
    }
}