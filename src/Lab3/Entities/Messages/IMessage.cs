namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IMessage
{
    int Priority { get; }
    string Title { get; }
    string Body { get; }
    string Content();
}