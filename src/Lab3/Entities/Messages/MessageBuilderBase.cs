using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class MessageBuilderBase : IMessageBuilder
{
    private string? _title;
    private string? _body;
    private int? _priority;

    public IMessageBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public IMessageBuilder WithBody(string content)
    {
        _body = content;
        return this;
    }

    public IMessageBuilder WithPriority(int priority)
    {
        _priority = priority;
        return this;
    }

    public IMessage Build()
    {
        return Create(
            _title ?? throw new ArgumentNullException(nameof(_title)),
            _body ?? throw new ArgumentNullException(nameof(_body)),
            _priority ?? throw new ArgumentNullException(nameof(_priority)));
    }

    protected abstract IMessage Create(
        string title,
        string content,
        int priority);
}