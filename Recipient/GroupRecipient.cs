using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.EndPoints;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class GroupRecipient : IRecipient
{
    private IList<IEndPoint> _users;

    public GroupRecipient(Log log, IList<IEndPoint> users)
    {
        Log = log;
        Title = string.Empty;
        _users = users;
    }

    public string Title { get; set; }
    public ILog Log { get; set; }

    public IEndPoint? EndPoint { get; set; }

    public void Receive(IList<Message> messages)
    {
        foreach (Message message in messages)
        {
            Receive(message);
        }
    }

    public void Receive(Message message)
    {
        Log.Add(new LogMessage(DateTime.Now, LogMessageType.Info, $"GroupRecipient received message {message}"));
        foreach (UserEndPoint user in _users)
        {
            Log.Add(new LogMessage(DateTime.Now, LogMessageType.Info, $"GroupRecipient send message to user:{user.Name}"));
            var userRecipient = new UserRecipient(Log, user);
            userRecipient.Receive(message);
        }

        if (EndPoint != null && message.Priority == EndPoint.GetMessagePriority())
            EndPoint.Receive(message);
    }

    public object Send(Message message)
    {
        throw new NotImplementedException();
    }
}