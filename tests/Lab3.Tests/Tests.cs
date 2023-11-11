using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Common;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void OnUserReceivingMessageItsUnread()
    {
        var message = new Message("wow", "wow", 1);
        IUser user = new User();
        user.ReceiveMessage(message);

        Assert.Equal(MessageStatus.Unread, user.CheckMessageStatus(0));
    }

    [Fact]
    public void OnReadMessageChangeStatus()
    {
        var message = new Message("wow", "wow", 3);
        IUser user = new User();
        user.ReceiveMessage(message);
        user.ReadMessage(0);

        Assert.Equal(MessageStatus.Read, user.CheckMessageStatus(0));
    }

    [Fact]
    public void OnReadReadMessageThrowsException()
    {
        var message = new Message("wow", "wow", 3);
        IUser user = new User();
        user.ReceiveMessage(message);
        user.ReadMessage(0);

        Assert.Throws<MessageStatusException>(() => user.ReadMessage(0));
    }

    [Fact]
    public void FilteredAdresseFiltersUnimportantMessage()
    {
        IAddresse user = Substitute.For<IAddresse>();
        int addresseMinPriority = 5;
        var filterAdresse = new FiltredByPriorityAddresse(
            user,
            addresseMinPriority);

        int messagePriority = 4;
        var message = new Message("bim", "bam", messagePriority);

        filterAdresse.ReceiveMessage(message);

        user.DidNotReceive().ReceiveMessage(message);
    }

    [Fact]
    public void LoggerAdresseLogsMessageOnRecieve()
    {
        IAddresse user = Substitute.For<IAddresse>();
        ILogger logger = Substitute.For<ILogger>();

        var loggerAdresse = new LoggingAddresse(
            user,
            logger);

        var message = new Message(
            "title",
            "body",
            5);

        loggerAdresse.ReceiveMessage(message);

        logger.Received().Log(message);
    }

    [Fact]
    public void MessengerShouldRecieveMessage()
    {
        ContainerDrawer drawer = Substitute.For<ContainerDrawer>();

        var message = new Message("bim", "bam", 0);
        var messenger = new Messenger(drawer);

        ITopic topic = new Topic("tiptopic", messenger);
        topic.ReceiveMessage(message);

        string messengerHeader = "Messenger : \n";
        drawer.Received().Draw(messengerHeader);
        drawer.Received().Draw(message.Content());
        Assert.Equal(drawer.Messages.First(), messengerHeader);
        Assert.Contains(drawer.Messages, messageContent => messageContent == message.Content());
    }
}