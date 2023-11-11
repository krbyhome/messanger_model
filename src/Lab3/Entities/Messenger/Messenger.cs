using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Messenger : IMessenger
{
    private readonly List<IMessage> _messages = new();
    private readonly IDrawer _drawer;

    public Messenger(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public void ReceiveMessage(IMessage message)
    {
        _messages.Add(message);
    }

    public void Draw(string content = "")
    {
        _drawer.Draw("Messenger :\n");
        foreach (IMessage message in _messages)
        {
            _drawer.Draw(message.Content());
        }
    }
}