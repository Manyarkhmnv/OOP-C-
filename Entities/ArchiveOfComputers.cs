using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ArchiveOfComputers
{
    private IList<Computer.Computer> _archiveOfComputers = new List<Computer.Computer>();
    public void AddComputer(Computer.Computer computer)
    {
        if (_archiveOfComputers.Contains(computer))
        {
            return;
        }

        _archiveOfComputers.Add(computer);
    }
}