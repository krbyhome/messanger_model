using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;

public abstract class Body : IDamageable
{
    private const int Endurance = 100;
    protected Body()
    {
        EnduranceBalance = new PhysicalDamage(Endurance);
    }

    public bool IsComplete => EnduranceBalance.PositiveOrZero();
    public int Dimensions { get; init; } // mass parameter
    public Damage EnduranceBalance { get; set; }
    public DamageResult TakeDamage(Damage damageTaken)
    {
        switch (damageTaken)
        {
            case FlashDamage:
                return new DamageResult.CrewDead();
            case CriticalDamage:
                return new DamageResult.SpaceShipDestroyed();
            case not PhysicalDamage:
                throw new ShipException("Unknowable type of damage");
        }

        EnduranceBalance.Subtract(damageTaken.Divide(Dimensions));
        if (EnduranceBalance.PositiveOrZero())
        {
            return new DamageResult.SpaceShipIsOk();
        }

        return new DamageResult.SpaceShipDestroyed();
    }
}