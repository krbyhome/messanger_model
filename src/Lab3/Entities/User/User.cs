using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Common;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IUser
{
    private readonly List<UserMessage> _messages = new();

    public void ReceiveMessage(IMessage message)
    {
            _messages.Add(new UserMessage(message));
    }

    public void ReadMessage(int messageIdx)
    {
        if (_messages[messageIdx].Status == MessageStatus.Read)
            throw new MessageStatusException("Trying to read read message");
        _messages[messageIdx].Status = MessageStatus.Read;
    }

    public MessageStatus CheckMessageStatus(int messageIdx)
    {
        return _messages[messageIdx].Status;
    }

    private class UserMessage : IMessage
    {
        private readonly IMessage _decorateeMessage;

        public UserMessage(IMessage message)
        {
            _decorateeMessage = message;
            Status = MessageStatus.Unread;
            Priority = message.Priority;
            Title = message.Title;
            Body = message.Body;
        }

        public MessageStatus Status { get; set; }

        public int Priority { get; }
        public string Title { get; }
        public string Body { get; }

        public string Content()
        {
            return _decorateeMessage.Content();
        }
    }
}