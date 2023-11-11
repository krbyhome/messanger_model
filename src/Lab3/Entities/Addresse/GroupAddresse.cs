using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class GroupAddresse : IAddresse
{
    private readonly IList<IAddresse> _addresses;

    public GroupAddresse(IList<IAddresse> addresses)
    {
        _addresses = addresses;
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IAddresse addresse in _addresses)
        {
            addresse.ReceiveMessage(message);
        }
    }
}