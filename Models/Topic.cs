namespace Itmo.ObjectOrientedProgramming.Lab3.Models;
public class Topic
{
    public Topic(string name, IRecipient recipient)
    {
        Name = name;
        Recipient = recipient;
    }

    public string Name { get;  set; }

    private IRecipient Recipient { get; set; }

    public void Send(Message message)
    {
        Recipient.Receive(message);
    }
}