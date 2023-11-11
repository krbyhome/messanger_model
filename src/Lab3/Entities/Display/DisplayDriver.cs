using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DisplayDriver : IDisplayDriver
{
    private readonly ColorModifier _colorModifier;
    private IClearableDrawer _drawer;

    public DisplayDriver(IClearableDrawer drawer)
    {
        _drawer = drawer;
        _colorModifier = new ColorModifier(Color.Black);
    }

    public void Draw(string content)
    {
        _drawer.Draw(_colorModifier.Modify(content));
    }

    public void Clear()
    {
        _drawer.Clear();
    }

    public void WithColor(Color color)
    {
        _colorModifier.WithColor(color);
    }
}