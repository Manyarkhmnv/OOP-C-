using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface ILog
{
    Collection<LogMessage> Messages { get; }

    void Add(LogMessage logMessage);

    void Clear();

    LogMessage GetMessage(int index);

    IEnumerable<LogMessage> GetMessage(DateTime fromDate, DateTime toDate);
}