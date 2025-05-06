using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class UserRecipient : IRecipient
{
    public UserRecipient(ILog log, IEndPoint endPoint)
    {
        Log = log;
        EndPoint = endPoint;
        Title = string.Empty;
    }

    public string Title { get; set; }
    public ILog Log { get; set; }

    public IEndPoint EndPoint { get; set; }

    public void Receive(IList<Message> messages)
    {
        foreach (Message message in messages)
        {
            Receive(message);
        }
    }

    public void Receive(Message message)
    {
        Log.Add(new LogMessage(DateTime.Now, LogMessageType.Info, $"UserRecipient received message {message}"));
        if (message.Priority == EndPoint.GetMessagePriority())
        {
            Log.Add(new LogMessage(DateTime.Now, LogMessageType.Info, $"UserRecipient send message to user"));
            message.Status = MessageStatus.Delivered;
            EndPoint.Receive(message);
        }
    }

    public object Send(Message message)
    {
        throw new NotImplementedException();
    }
}