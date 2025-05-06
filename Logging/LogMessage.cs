using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class LogMessage : BaseMessage
{
    public LogMessage(DateTime createDate, LogMessageType type, string title = "", string description = "")
        : base(
            createDate, title, description)
    {
        Type = type;
    }

    public LogMessage()
        : this(DateTime.Now, LogMessageType.Info, $"Message {DateTime.Now}")
    {
    }

    public LogMessageType Type { get; set; }

    public override string MakeBody()
    {
        string body = $"{Type}: {Title}";
        if (!string.IsNullOrEmpty(Description)) body += $" - {Description}";

        return body;
    }
}