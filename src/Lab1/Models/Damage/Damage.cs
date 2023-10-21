using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;

public abstract class Damage
{
    protected Damage(int value)
    {
        Value = value;
    }

    private decimal Value { get; set; }

    public bool Positive()
    {
        return Value > 0;
    }

    public bool PositiveOrZero()
    {
        return Value >= 0;
    }

    public bool Negative()
    {
        return Value < 0;
    }

    public bool Zero()
    {
        return Value == 0;
    }

    public Damage Subtract(Damage right)
    {
        if (right is null)
        {
            throw new ArgumentNullException(nameof(right), "HealthPoint parameter cannot be null");
        }

        Value -= right.Value;
        return this;
    }

    public Damage Divide(Damage right)
    {
        if (right is null)
        {
            throw new ArgumentNullException(nameof(right), "HealthPoint parameter cannot be null");
        }

        Value /= right.Value;
        return this;
    }

    public Damage Divide(int right)
    {
        Value /= right;
        return this;
    }
}