using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhale : INitrineParticleNebulaeObstacle
{
    private readonly CriticalDamage _damage = new CriticalDamage(4000);

    public DamageResult Hit(IDamageable target)
    {
        return target.TakeDamage(_damage);
    }
}