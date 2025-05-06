using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.EndPoints;

public class MessengerEndPoint : IEndPoint
{
    private IList<Message> _messages;
    public MessengerEndPoint(string name, MessagePriority priority)
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

        Print();
    }

    public void Receive(IList<Message> messages)
    {
        foreach (Message message in messages)
        {
            Receive(message);
        }

        Print();
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

            return message;
        }

        throw new NotImplementedException();
    }

    public void Print()
    {
        Console.WriteLine("All messages from Messenger: ");
        if (Messages != null)
        {
            for (int i = 0; i < Messages.Count; i++)
            {
                Console.WriteLine(Read(i));
            }
        }
    }

    public MessagePriority GetMessagePriority()
    {
        return Priority;
    }
}