using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimaterialFlash : ISubspaceThreadObstacle
{
    private readonly FlashDamage _damage = new FlashDamage(1);

    public DamageResult Hit(IDamageable target)
    {
        return target.TakeDamage(_damage);
    }
}