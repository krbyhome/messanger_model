using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : IDefaultSpaceObstacle
{
    private readonly PhysicalDamage _damage = new PhysicalDamage(200);

    public DamageResult Hit(IDamageable target)
    {
        return target.TakeDamage(_damage);
    }
}