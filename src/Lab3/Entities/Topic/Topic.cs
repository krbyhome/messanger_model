namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic : ITopic
{
    public Topic(
        string name,
        IAddresse addresse)
    {
        Name = name;
        Addresse = addresse;
    }

    public string Name { get; }
    public IAddresse Addresse { get; }
    public void ReceiveMessage(IMessage message)
    {
        Addresse.ReceiveMessage(message);
    }
}