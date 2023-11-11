using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class ColorModifier : IModifier
{
    private Color _color;

    public ColorModifier(Color color)
    {
        _color = color;
    }

    public string Modify(string value)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(value);
    }

    public void WithColor(Color color)
    {
        _color = color;
    }
}