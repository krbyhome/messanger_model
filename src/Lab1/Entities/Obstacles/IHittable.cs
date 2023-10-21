using Itmo.ObjectOrientedProgramming.Lab1.Common;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public interface IHittable
{
    public DamageResult Hit(IDamageable target);
}