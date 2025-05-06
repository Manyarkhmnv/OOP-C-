using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IEndPoint
{
    public string Name { get; set; }
    public MessagePriority Priority { get; }

    public void Receive(Message message);

    public void Receive(IList<Message> messages);

    public Message Read(int messageIndex);

    public MessagePriority GetMessagePriority();
}