using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Common;

public class MessageStatusException : Exception
{
    public MessageStatusException()
        : base()
    {
    }

    public MessageStatusException(string message)
        : base(message)
    {
    }

    public MessageStatusException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}