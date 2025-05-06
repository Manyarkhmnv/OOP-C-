using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class Log : ILog
{
    internal Log()
    {
        Messages = new Collection<LogMessage>();
    }

    public Collection<LogMessage> Messages { get; }

    public void Add(LogMessage logMessage)
    {
        Messages.Add(logMessage);
    }

    public void Clear()
    {
        Messages.Clear();
    }

    public LogMessage GetMessage(int index)
    {
        if (index < 0 || index >= Messages.Count)
            throw new ArgumentOutOfRangeException(nameof(index), index, "Индекс находится вне допустимого диапазона.");

        return Messages[index];
    }

    public IEnumerable<LogMessage> GetMessage(DateTime fromDate, DateTime toDate)
    {
        if (fromDate > toDate) throw new ArgumentException("Дата 'from' должна быть меньше или равна дате 'to'.");

        return Messages.Where(x => x.CreateDate >= fromDate && x.CreateDate <= toDate);
    }
}