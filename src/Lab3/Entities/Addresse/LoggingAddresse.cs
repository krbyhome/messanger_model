using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class LoggingAddresse : IAddresse
{
    private IAddresse _addresse;
    private ILogger _logger;

    public LoggingAddresse(
        IAddresse addresse,
        ILogger logger)
    {
        _addresse = addresse;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.Log(message);
        _addresse.ReceiveMessage(message);
    }
}