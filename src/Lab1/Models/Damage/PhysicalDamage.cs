namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

public class PhysicalDamage : Damage
{
    public PhysicalDamage()
        : base(0)
    {
    }

    public PhysicalDamage(int value)
        : base(value)
    {
    }
}