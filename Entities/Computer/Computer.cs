using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerUnitComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class Computer
{
    private ICpu? _cpu;
    private IFan? _cpuCoolingSystem;
    private IFrame? _frame;
    private IMotherboard? _motherboard;
    private IPowerUnit? _powerUnit;
    private Components.RamComponent.IRam? _ram;
    private IList<IDrive> _drives;
    private Components.VideoCardComponent.IVideoCard? _videoCard;
    public Computer(ICpu? cpu, IFan cpuCoolingSystem, IFrame frame, IMotherboard? motherboard, IPowerUnit powerUnit, Components.RamComponent.IRam ram, IList<IDrive> drives, Components.VideoCardComponent.IVideoCard videoCard)
    {
        this._cpu = cpu;
        _cpuCoolingSystem = cpuCoolingSystem;
        _frame = frame;
        _motherboard = motherboard;
        _powerUnit = powerUnit;
        _ram = ram;
        _drives = drives;
        _videoCard = videoCard;
    }
}