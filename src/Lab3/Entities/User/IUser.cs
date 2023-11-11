namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IUser : IAddresse
{
    void ReadMessage(int messageIdx);
    MessageStatus CheckMessageStatus(int messageIdx);
}