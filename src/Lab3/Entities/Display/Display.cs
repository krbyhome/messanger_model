using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Display : IDisplay
{
    private IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ReceiveMessage(IMessage message)
    {
        _displayDriver.Clear();
        _displayDriver.Draw(message.Content());
    }

    public void SetColor(Color color)
    {
         _displayDriver.WithColor(color);
    }
}