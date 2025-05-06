using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public enum MessageStatus
{
    Created, // Сообщение создано, но еще не отправлено
    Sent, // Сообщение отправлено
    Delivered, // Сообщение доставлено получателю (непрочитано)
    Read, // Сообщение прочитано получателем
    Failed, // Ошибка при отправке сообщения
    Archived, // Сообщение архивировано
}

public enum MessagePriority
{
    Low, // Низкий приоритет
    Normal, // Обычный приоритет
    High, // Высокий приоритет
    Urgent, // Срочный приоритет
}

public class Message : BaseMessage
{
    private MessageStatus _status;

    internal Message(string title, string description, MessagePriority priority)
        : base(DateTime.Now, title, description)
    {
        Priority = priority;
        Status = MessageStatus.Created;
    }

    public MessagePriority Priority { get; set; }

    public MessageStatus Status
    {
        get
        {
            return _status;
        }
        set
        {
            if (value == MessageStatus.Read && this._status == value)
                throw new ArgumentException("Message already read");
            _status = value;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Message)obj;
        return base.Equals(other) &&
               Priority == other.Priority &&
               Status == other.Status;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Title, Description, Priority, Status);
    }
}