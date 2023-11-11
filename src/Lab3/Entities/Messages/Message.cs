namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message : IMessage
{
    public Message(
        string title,
        string body,
        int priority)
    {
        Title = title;
        Body = body;
        Priority = priority;
    }

    public string Title { get; }
    public string Body { get; }
    public int Priority { get; }

    public string Content()
    {
        return $"Title : {Title}\n\t Content: {Body}\n";
    }
}