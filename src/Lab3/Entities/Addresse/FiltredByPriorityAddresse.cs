namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class FiltredByPriorityAddresse : IAddresse
{
    private IAddresse _addresse;
    private int _minPriority;

    public FiltredByPriorityAddresse(
        IAddresse addresse,
        int minPriority)
    {
        _addresse = addresse;
        _minPriority = minPriority;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message.Priority >= _minPriority)
        {
            _addresse.ReceiveMessage(message);
        }
    }
}