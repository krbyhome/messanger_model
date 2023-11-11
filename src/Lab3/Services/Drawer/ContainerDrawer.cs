using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ContainerDrawer : IDrawer
{
    private readonly IList<string> _messages;

    public ContainerDrawer()
    {
        _messages = new List<string>();
    }

    public IEnumerable<string> Messages => _messages.AsReadOnly();

    public void Draw(string content)
    {
        _messages.Add(content);
    }
}