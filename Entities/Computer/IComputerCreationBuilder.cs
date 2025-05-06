using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerUnitComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public interface IComputerCreationBuilder
{
    Result CpuBuilder(Cpu cpu);
    Result CpuCoolingSystemBuilder(Fan fan);
    Result FrameBuilder(Frame frame);
    Result SsdDriveBuilder(IDrive ssd);
    Result MotherboardBuilder(Motherboard motherboard);
    Result PowerUnitBuilder(PowerUnit powerUnit);
    Result RamBuilder(Ram ram);
    Result HddBuilder(IDrive hdd);
    Result VideoCardbuilder(Components.VideoCardComponent.VideoCard videocard);
    void AddingToArchive(ArchiveOfComputers archiveOfComputers);
}