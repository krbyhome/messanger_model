using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Logger : ILogger
{
    private IDrawer _drawer;

    public Logger(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public void Log(IMessage message)
    {
        _drawer.Draw(message.Content());
    }
}