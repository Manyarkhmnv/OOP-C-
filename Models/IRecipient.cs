using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IRecipient
{
    public object Send(Message message);
    void Receive(Message message);
    void Receive(IList<Message> messages);
}