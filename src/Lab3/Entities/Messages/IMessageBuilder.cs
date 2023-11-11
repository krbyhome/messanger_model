namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IMessageBuilder
{
    IMessageBuilder WithTitle(string title);
    IMessageBuilder WithBody(string content);
    IMessageBuilder WithPriority(int priority);

    IMessage Build();
}