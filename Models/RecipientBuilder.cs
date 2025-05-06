using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.EndPoints;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientBuilder
{
    private Log _log;

    public RecipientBuilder(Log log)
    {
        _log = log;
    }

    public Log Log { get { return _log; } }

    public UserRecipient UserBuilder(UserEndPoint user)
    {
        return new UserRecipient(Log, user);
    }

    public DisplayRecipient DisplayBuilder(DisplayEndPoint display)
    {
        return new DisplayRecipient(Log, display);
    }

    public MessengerRecipient MessengerBuilder(MessengerEndPoint messenger)
    {
        return new MessengerRecipient(Log, messenger);
    }

    public GroupRecipient GroupBuilder(IList<IEndPoint> users)
    {
        return new GroupRecipient(Log, users);
    }
}