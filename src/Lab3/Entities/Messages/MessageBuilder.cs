namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MessageBuilder : MessageBuilderBase
{
    protected override IMessage Create(string title, string content, int priority)
    {
        return new Message(title, content, priority);
    }
}