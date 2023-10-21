using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Bodies;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public abstract class SpaceShip : IDamageable, ITravelable
{
    private readonly List<IConsumingFuel> _engines;
    private readonly Body _body;

    protected SpaceShip(IEnumerable<IConsumingFuel> engines, Body body, Deflector? deflector = null)
    {
        _engines = engines.ToList();
        Deflector = deflector;
        _body = body;
    }

    public IReadOnlyCollection<IConsumingFuel> Engines => _engines;
    public Deflector? Deflector { get; protected set; }

    public virtual DamageResult TakeDamage(Damage damageTaken)
    {
        if (Deflector is not null && Deflector.IsComplete)
        {
            return Deflector.TakeDamage(damageTaken);
        }

        return _body.IsComplete ? _body.TakeDamage(damageTaken)
                        : new DamageResult.SpaceShipDestroyed();
    }

    public TravelSectionResult Travel(Section section)
    {
        EngineRunResult engineResult = new EngineRunResult.DistanceLimitReached(section.Distance);
        foreach (IConsumingFuel engine in _engines)
        {
            engineResult = engine.ConsumeFuel(section);
            if (engineResult is EngineRunResult.Success)
            {
                break;
            }
        }

        DamageResult damageResult = new DamageResult.SpaceShipIsOk();
        foreach (IHittable enviromentObstacle in section.Enviroment.Obstacles)
        {
            damageResult = enviromentObstacle.Hit(this);
            if (damageResult is DamageResult.CrewDead or DamageResult.SpaceShipDestroyed)
            {
                break;
            }
        }

        return new TravelSectionResult(damageResult, engineResult);
    }
}