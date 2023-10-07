namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

public class CriticalDamage : Damage
{
    public CriticalDamage()
        : base(0)
    {
    }

    public CriticalDamage(int value)
        : base(value)
    {
    }
}