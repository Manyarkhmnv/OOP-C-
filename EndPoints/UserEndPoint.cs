using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.EndPoints;

public class UserEndPoint : IEndPoint
{
    private readonly IList<Message> _messages;
    public UserEndPoint(string name, MessagePriority priority)
    {
        Name = name;
        _messages = new List<Message>();
        Priority = priority;
    }

    public string Name { get; set; }

    public IReadOnlyList<Message>? Messages { get { return _messages as IReadOnlyList<Message>; } }

    public MessagePriority Priority { get; }
    public void Receive(Message message)
    {
        message.Status = MessageStatus.Delivered;
        _messages.Add(message);
    }

    public void Receive(IList<Message> messages)
    {
        foreach (Message message in messages)
        {
            Receive(message);
        }
    }

    public Message Read(int messageIndex)
    {
        if (Messages != null && (messageIndex < 0 || messageIndex >= Messages.Count))
        {
            throw new ArgumentOutOfRangeException(nameof(messageIndex), "Индекс находится вне диапазона.");
        }

        if (Messages != null)
        {
            Message message = Messages[messageIndex];
            message.Status = MessageStatus.Read;
            return message;
        }

        throw new NotImplementedException();
    }

    public MessagePriority GetMessagePriority()
    {
        return Priority;
    }
}