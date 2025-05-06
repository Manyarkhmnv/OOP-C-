using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public abstract class BaseMessage
{
    internal BaseMessage(DateTime createDate, string title = "", string description = "")
    {
        CreateDate = createDate;
        Title = title;
        Description = description;
    }

    internal BaseMessage()
        : this(DateTime.Now, $"Message {DateTime.Now}")
    {
    }

    public DateTime CreateDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual string MakeBody()
    {
        return $"{Title}.{Description}";
    }

    public override string ToString()
    {
        return $"[{CreateDate:yyyy-MM-dd HH:mm:ss}] :{MakeBody()}";
    }
}