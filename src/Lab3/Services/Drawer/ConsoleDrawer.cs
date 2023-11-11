using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ConsoleDrawer : IClearableDrawer
{
    public void Draw(string content)
    {
        Console.WriteLine(content);
    }

    public void Clear()
    {
        Console.Clear();
    }
}