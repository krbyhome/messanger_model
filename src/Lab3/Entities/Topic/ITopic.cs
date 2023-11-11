namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ITopic
{
    string Name { get; }
    IAddresse Addresse { get; }
    void ReceiveMessage(IMessage message);
}