using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.HddComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerUnitComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SsdDriveComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ComputerBuilder
{
    private ICpu? _cpu;
    private IFan? _fan;
    private IFrame? _frame;
    private IMotherboard? _motherboard;
    private IPowerUnit? _powerUnit;
    private IRam? _ram;
    private IList<IDrive> _drives;
    private IVideoCard? _videoCard;
    internal ComputerBuilder()
    {
        _cpu = null;
        _fan = null;
        _frame = null;
        _motherboard = null;
        _powerUnit = null;
        _ram = null;
        _drives = new List<IDrive>();
        _videoCard = null;
    }

    public Result? WithFrame(IFrame frame)
    {
        if (frame != null)
        {
            if (frame.Equals(_motherboard) == false && frame.Equals(_videoCard) == false)
            {
                return Result.Incompatibility;
            }
            else
            {
                _frame = frame;
                return Result.Success;
            }
        }

        return Result.InstallationIsNotInStrictOrder;
    }

// 2) процессор
    public Result? WithCpu(ICpu? cpu)
    {
        if (_motherboard == null)
        {
            return Result.InstallationIsNotInStrictOrder;
        }

        if (_motherboard.Equals(cpu))
        {
            _cpu = cpu;
            return Result.Success;
        }

        return Result.InstallationIsNotInStrictOrder;
    }

// 1) матплата
    public Result? WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return Result.Success;
    }

    // 4) видеокарта
    public Result WithVideoCard(VideoCard videocard)
    {
        if (_fan == null)
        {
            return Result.InstallationIsNotInStrictOrder;
        }

        _videoCard = videocard;
        return Result.Success;
    }

    // 6) оперативка
    public Result WithRam(Ram ram)
    {
        if (_drives == null)
        {
            return Result.InstallationIsNotInStrictOrder;
        }

        if (!(_motherboard != null && _motherboard.Equals(ram)))
        {
            return Result.Incompatibility;
        }

        _ram = ram;

        return Result.Success;
    }

    // 5) ссд или hdd
    public Result WithHdd(IDrive hdd)
    {
        if (_cpu?.PresenceOfVideoCore != null && _videoCard == null && _cpu != null && _cpu.PresenceOfVideoCore.Presence == false)
        {
            return Result.NoImageOutput;
        }

        _drives.Add(hdd);

        return Result.Success;
    }

    public Result WithSsdDrive(IDrive ssd)
    {
        if (_cpu?.PresenceOfVideoCore != null && _videoCard == null && _cpu != null && _cpu.PresenceOfVideoCore.Presence == false)
        {
            return Result.NoImageOutput;
        }

        _drives.Add(ssd);
        return Result.Success;
    }

    // 3) кулер
    public Result WithCpuCoolingSystem(Fan fan)
    {
        if (_cpu == null)
        {
            return Result.InstallationIsNotInStrictOrder;
        }

        if (_motherboard != null && _motherboard.Equals(fan) == true)
        {
            return Result.Incompatibility;
        }

        _fan = fan;
        if (!_fan.Equals(_cpu))
        {
            return Result.DisclaimerOfWarrantyService;
        }

        return Result.Success;
    }

    // 7) блок питания
    public Result WithPowerUnit(PowerUnit powerUnit)
    {
        var drives = new Collection<IDrive>();
        for (int i = 0; i < _drives.Count; i++)
        {
            drives.Add(_drives[i]);
        }

        if (_cpu?.PresenceOfVideoCore != null && _cpu != null && _videoCard == null && _cpu.PresenceOfVideoCore.Presence == false)
        {
            return Result.InstallationIsNotInStrictOrder;
        }

        _powerUnit = powerUnit;
        if (_powerUnit.Equals(drives, _videoCard, _ram, _cpu))
        {
            return Result.Success;
        }

        return Result.SuccessWithWarning;
    }

    public void FanDebuilder(FormFactorOfCpuCoolingSystem characteristic)
    {
        var builder = new Fan.FanBuilder();
        if (_fan != null && _fan.Socket != null && _fan.MaxTdp != null && _fan.FormFactor != null)
        {
            builder.Add(characteristic).Add(_fan.Socket).Add(_fan.MaxTdp);
        }

        Fan fan = builder.Build();
        Result? result = WithCpuCoolingSystem(fan);
        if (result == Result.Success)
        {
            _fan = fan;
            Build();
        }
    }

    public void FanDebuilder(Socket characteristic)
    {
        var builder = new Fan.FanBuilder();
        if (_fan != null && _fan.Socket != null && _fan.MaxTdp != null && _fan.FormFactor != null)
        {
            builder.Add(characteristic).Add(_fan.FormFactor).Add(_fan.MaxTdp);
        }

        Fan fan = builder.Build();
        Result? result = WithCpuCoolingSystem(fan);
        if (result == Result.Success)
        {
            _fan = fan;
            Build();
        }
    }

    public void FanDebuilder(MaxTdp characteristic)
    {
        var builder = new Fan.FanBuilder();
        if (_fan != null && _fan.Socket != null && _fan.MaxTdp != null && _fan.FormFactor != null)
        {
            builder.Add(characteristic).Add(_fan.Socket).Add(_fan.Socket);
        }

        Fan fan = builder.Build();
        Result? result = WithCpuCoolingSystem(fan);
        if (result == Result.Success)
        {
            _fan = fan;
            Build();
        }
    }

    public void PowerUnitDebuilder(PowerConsumption characteristic)
    {
        var builder = new PowerUnit.PowerUnitBuilder();
        if (_powerUnit != null)
        {
            builder.Add(characteristic);
        }

        PowerUnit powerUnit = builder.Build();
        Result? result = WithPowerUnit(powerUnit);
        if (result == Result.Success)
        {
            _powerUnit = powerUnit;
            Build();
        }
    }

    public void HddDebuilder(PowerConsumption characteristic)
    {
        var builder = new Hdd.HddBuilder();
        if (_drives[0] != null)
        {
            builder.Add(characteristic);
        }

        Hdd hdd = builder.Build();
        Result? result = WithHdd(hdd);
        if (result == Result.Success)
        {
            _drives[0] = hdd;
            Build();
        }
    }

    public void SsdDebuilder(PowerConsumption characteristic)
    {
        var builder = new Ssd.SsdBuilder();
        if (_drives[1] != null)
        {
            builder.Add(characteristic);
        }

        Ssd ssd = builder.Build();
        Result? result = WithHdd(ssd);
        if (result == Result.Success)
        {
            _drives[1] = ssd;
            Build();
        }
    }

    public void RamDebuilder(Memory characteristic)
    {
        var builder = new Ram.RamBuilder();
        if ((_ram?.Memory != null) && (_ram.Frequency != null) && (_ram.FormFactor != null) && (_ram.StandardDdr != null))
        {
            builder.Add(characteristic).Add(_ram.Frequency).Add(_ram.FormFactor).Add(_ram.StandardDdr);
        }

        Ram ram = builder.Build();
        Result? result = WithRam(ram);
        if (result == Result.Success)
        {
            _ram = ram;
            Build();
        }
    }

    public void RamDebuilder(ChipFrequency characteristic)
    {
        var builder = new Ram.RamBuilder();
        if ((_ram?.Memory != null) && (_ram.Frequency != null) && (_ram.FormFactor != null) && (_ram.StandardDdr != null))
        {
            builder.Add(characteristic).Add(_ram.Memory).Add(_ram.FormFactor).Add(_ram.StandardDdr);
        }

        Ram ram = builder.Build();
        Result? result = WithRam(ram);
        if (result == Result.Success)
        {
            _ram = ram;
            Build();
        }
    }

    public void RamDebuilder(FormFactorOfRam characteristic)
    {
        var builder = new Ram.RamBuilder();
        if ((_ram?.Memory != null) && (_ram.Frequency != null) && (_ram.FormFactor != null) && (_ram.StandardDdr != null))
        {
            builder.Add(characteristic).Add(_ram.Frequency).Add(_ram.Memory).Add(_ram.StandardDdr);
        }

        Ram ram = builder.Build();
        Result? result = WithRam(ram);
        if (result == Result.Success)
        {
            _ram = ram;
            Build();
        }
    }

    public void RamDebuilder(StandardDdr characteristic)
    {
        var builder = new Ram.RamBuilder();
        if ((_ram?.Memory != null) && (_ram.Frequency != null) && (_ram.FormFactor != null) && (_ram.StandardDdr != null))
        {
            builder.Add(characteristic).Add(_ram.Frequency).Add(_ram.FormFactor).Add(_ram.Memory);
        }

        Ram ram = builder.Build();
        Result? result = WithRam(ram);
        if (result == Result.Success)
        {
            _ram = ram;
            Build();
        }
    }

    public void VideocardDebuilder(Dimensions characteristic)
    {
        var videoCardBuilder = new VideoCard.VideoCardBuilder();
        if ((_videoCard?.FormFactor != null) && (_videoCard.AmountOfPciELines != null) && (_videoCard.AmountOfVideoMemory != null) && (_videoCard.ChipFrequency != null) && _videoCard.PowerConsumption != null)
        {
            videoCardBuilder.Add(characteristic).Add(_videoCard.AmountOfPciELines).Add(_videoCard.AmountOfVideoMemory).Add(_videoCard.ChipFrequency).Add(_videoCard.PowerConsumption);
        }

        VideoCard videoCard = videoCardBuilder.Build();
        Result? result = WithVideoCard(videoCard);
        if (result == Result.Success)
        {
            _videoCard = videoCard;
            Build();
        }
    }

    public void VideocardDebuilder(PciE characteristic)
    {
        var videoCardBuilder = new VideoCard.VideoCardBuilder();
        if ((_videoCard?.FormFactor != null) && (_videoCard.AmountOfPciELines != null) && (_videoCard.AmountOfVideoMemory != null) && (_videoCard.ChipFrequency != null) && _videoCard.PowerConsumption != null)
        {
            videoCardBuilder.Add(characteristic).Add(_videoCard.FormFactor).Add(_videoCard.AmountOfVideoMemory).Add(_videoCard.ChipFrequency).Add(_videoCard.PowerConsumption);
        }

        VideoCard videoCard = videoCardBuilder.Build();
        Result? result = WithVideoCard(videoCard);
        if (result == Result.Success)
        {
            _videoCard = videoCard;
            Build();
        }
    }

    public void VideocardDebuilder(ChipFrequency characteristic)
    {
        var videoCardBuilder = new VideoCard.VideoCardBuilder();
        if ((_videoCard?.FormFactor != null) && (_videoCard.AmountOfPciELines != null) && (_videoCard.AmountOfVideoMemory != null) && (_videoCard.ChipFrequency != null) && _videoCard.PowerConsumption != null)
        {
            videoCardBuilder.Add(characteristic).Add(_videoCard.AmountOfPciELines).Add(_videoCard.AmountOfVideoMemory).Add(_videoCard.FormFactor).Add(_videoCard.PowerConsumption);
        }

        VideoCard videoCard = videoCardBuilder.Build();
        Result? result = WithVideoCard(videoCard);
        if (result == Result.Success)
        {
            _videoCard = videoCard;
            Build();
        }
    }

    public void VideocardDebuilder(PowerConsumption characteristic)
    {
        var videoCardBuilder = new VideoCard.VideoCardBuilder();
        if ((_videoCard?.FormFactor != null) && (_videoCard.AmountOfPciELines != null) && (_videoCard.AmountOfVideoMemory != null) && (_videoCard.ChipFrequency != null) && _videoCard.PowerConsumption != null)
        {
            videoCardBuilder.Add(characteristic).Add(_videoCard.AmountOfPciELines).Add(_videoCard.AmountOfVideoMemory).Add(_videoCard.ChipFrequency).Add(_videoCard.FormFactor);
        }

        VideoCard videoCard = videoCardBuilder.Build();
        Result? result = WithVideoCard(videoCard);
        if (result == Result.Success)
        {
            _videoCard = videoCard;
            Build();
        }
    }

    public void VideocardDebuilder(VideoMemory characteristic)
    {
        var videoCardBuilder = new VideoCard.VideoCardBuilder();
        if ((_videoCard?.FormFactor != null) && (_videoCard.AmountOfPciELines != null) && (_videoCard.AmountOfVideoMemory != null) && (_videoCard.ChipFrequency != null) && _videoCard.PowerConsumption != null)
        {
            videoCardBuilder.Add(characteristic).Add(_videoCard.AmountOfPciELines).Add(_videoCard.FormFactor).Add(_videoCard.ChipFrequency).Add(_videoCard.PowerConsumption);
        }

        VideoCard videoCard = videoCardBuilder.Build();
        Result? result = WithVideoCard(videoCard);
        if (result == Result.Success)
        {
            _videoCard = videoCard;
            Build();
        }
    }

    public void FrameDebuilder(FormFactorOfMotherboard characteristic)
    {
        var frameBuilder = new Frame.FrameBuilder();
        if ((_frame?.FormFactorOfVideocard != null) && (_frame.FormFactorsOfMotherboard != null) && (_frame.FormFactorOfFrame != null))
        {
            frameBuilder.Add(characteristic).Add(_frame.FormFactorOfVideocard).Add(_frame.FormFactorOfFrame);
        }

        Frame frame = frameBuilder.Build();
        Result? result = WithFrame(frame);
        if (result == Result.Success)
        {
            _frame = frame;
            Build();
        }
    }

    public void FrameDebuilder(Dimensions characteristic)
    {
        var frameBuilder = new Frame.FrameBuilder();
        if ((_frame?.FormFactorOfVideocard != null) && (_frame.FormFactorsOfMotherboard != null) && (_frame.FormFactorOfFrame != null))
        {
            frameBuilder.Add(characteristic).Add(_frame.FormFactorsOfMotherboard).Add(_frame.FormFactorOfFrame);
        }

        Frame frame = frameBuilder.Build();
        Result? result = WithFrame(frame);
        if (result == Result.Success)
        {
            _frame = frame;
            Build();
        }
    }

    public void FrameDebuilder(FormFactorOfFrame characteristic)
    {
        var frameBuilder = new Frame.FrameBuilder();
        if ((_frame?.FormFactorOfVideocard != null) && (_frame.FormFactorsOfMotherboard != null) && (_frame.FormFactorOfFrame != null))
        {
            frameBuilder.Add(characteristic).Add(_frame.FormFactorsOfMotherboard).Add(_frame.FormFactorOfVideocard);
        }

        Frame frame = frameBuilder.Build();
        Result? result = WithFrame(frame);
        if (result == Result.Success)
        {
            _frame = frame;
            Build();
        }
    }

    public void MotherboardDebuilder(Socket characteristic)
    {
        var motherboardBuilder = new Motherboard.MotherboardBuilder();
        if ((_motherboard?.Socket != null) && (_motherboard.PciE != null) && (_motherboard.SataPorts != null) && (_motherboard.Chipset != null) && (_motherboard.TablesRam != null) && _motherboard.StandardDdr != null)
        {
            motherboardBuilder.Add(characteristic).Add(_motherboard.PciE).Add(_motherboard.SataPorts).Add(_motherboard.Chipset).Add(_motherboard.TablesRam).Add(_motherboard.StandardDdr);
        }

        Motherboard motherboard = motherboardBuilder.Build();
        Result? withmotherboard = WithMotherboard(motherboard);
        if (withmotherboard == Result.Success)
        {
            _motherboard = motherboard;
            Build();
        }
    }

    public void MotherboardDebuilder(PciE characteristic)
    {
        var motherboardBuilder = new Motherboard.MotherboardBuilder();
        if ((_motherboard?.Socket != null) && (_motherboard.PciE != null) && (_motherboard.SataPorts != null) && (_motherboard.Chipset != null) && (_motherboard.TablesRam != null) && _motherboard.StandardDdr != null)
        {
            motherboardBuilder.Add(characteristic).Add(_motherboard.Socket).Add(_motherboard.SataPorts).Add(_motherboard.Chipset).Add(_motherboard.TablesRam).Add(_motherboard.StandardDdr);
        }

        Motherboard motherboard = motherboardBuilder.Build();
        Result? withmotherboard = WithMotherboard(motherboard);
        if (withmotherboard == Result.Success)
        {
            _motherboard = motherboard;
            Build();
        }
    }

    public void MotherboardDebuilder(SataPorts characteristic)
    {
        var motherboardBuilder = new Motherboard.MotherboardBuilder();
        if ((_motherboard?.Socket != null) && (_motherboard.PciE != null) && (_motherboard.SataPorts != null) && (_motherboard.Chipset != null) && (_motherboard.TablesRam != null) && _motherboard.StandardDdr != null)
        {
            motherboardBuilder.Add(characteristic).Add(_motherboard.PciE).Add(_motherboard.Socket).Add(_motherboard.Chipset).Add(_motherboard.TablesRam).Add(_motherboard.StandardDdr);
        }

        Motherboard motherboard = motherboardBuilder.Build();
        Result? withmotherboard = WithMotherboard(motherboard);
        if (withmotherboard == Result.Success)
        {
            _motherboard = motherboard;
            Build();
        }
    }

    public void MotherboardDebuilder(Chipset characteristic)
    {
        var motherboardBuilder = new Motherboard.MotherboardBuilder();
        if ((_motherboard?.Socket != null) && (_motherboard.PciE != null) && (_motherboard.SataPorts != null) && (_motherboard.Chipset != null) && (_motherboard.TablesRam != null) && _motherboard.StandardDdr != null)
        {
            motherboardBuilder.Add(characteristic).Add(_motherboard.PciE).Add(_motherboard.SataPorts).Add(_motherboard.Socket).Add(_motherboard.TablesRam).Add(_motherboard.StandardDdr);
        }

        Motherboard motherboard = motherboardBuilder.Build();
        Result? withmotherboard = WithMotherboard(motherboard);
        if (withmotherboard == Result.Success)
        {
            _motherboard = motherboard;
            Build();
        }
    }

    public void MotherboardDebuilder(StandardDdr characteristic)
    {
        var motherboardBuilder = new Motherboard.MotherboardBuilder();
        if ((_motherboard?.Socket != null) && (_motherboard.PciE != null) && (_motherboard.SataPorts != null) && (_motherboard.Chipset != null) && (_motherboard.TablesRam != null) && _motherboard.StandardDdr != null)
        {
            motherboardBuilder.Add(characteristic).Add(_motherboard.PciE).Add(_motherboard.SataPorts).Add(_motherboard.Chipset).Add(_motherboard.TablesRam).Add(_motherboard.Socket).Add(_motherboard.StandardDdr);
        }

        Motherboard motherboard = motherboardBuilder.Build();
        Result? withmotherboard = WithMotherboard(motherboard);
        if (withmotherboard == Result.Success)
        {
            _motherboard = motherboard;
            Build();
        }
    }

    public void MotherboardDebuilder(TablesRam characteristic)
    {
        var motherboardBuilder = new Motherboard.MotherboardBuilder();
        if ((_motherboard?.Socket != null) && (_motherboard.PciE != null) && (_motherboard.SataPorts != null) && (_motherboard.Chipset != null) && (_motherboard.TablesRam != null) && _motherboard.StandardDdr != null)
        {
            motherboardBuilder.Add(characteristic).Add(_motherboard.PciE).Add(_motherboard.SataPorts).Add(_motherboard.Chipset).Add(_motherboard.Socket).Add(_motherboard.StandardDdr);
        }

        Motherboard motherboard = motherboardBuilder.Build();
        Result? withmotherboard = WithMotherboard(motherboard);
        if (withmotherboard == Result.Success)
        {
            _motherboard = motherboard;
            Build();
        }
    }

    public void CpuDebuilder(Cores characteristic)
    {
        var cpuBuilder = new Cpu.CpuBuilder();
        if ((_cpu?.Socket != null) && (_cpu.PresenceOfVideoCore != null) && (_cpu.Frequency != null) && (_cpu.Tdp != null) && (_cpu.PowerConsumption != null) && (_cpu != null))
        {
            cpuBuilder.Add(characteristic).Add(_cpu.Socket).Add(_cpu.PresenceOfVideoCore).Add(_cpu.Frequency).Add(_cpu.Tdp).Add(_cpu.PowerConsumption);
        }

        Cpu cpu = cpuBuilder.Build();
        Result? withCpu = WithCpu(cpu);
        if (withCpu == Result.Success)
        {
            _cpu = cpu;
            Build();
        }
    }

    public void CpuDebuilder(Socket characteristic)
    {
        var cpuBuilder = new Cpu.CpuBuilder();
        if ((_cpu?.AmountOfCores != null) && (_cpu.PresenceOfVideoCore != null) && (_cpu.Frequency != null) && (_cpu.Tdp != null) && (_cpu.PowerConsumption != null) && (_cpu != null))
        {
            cpuBuilder.Add(characteristic).Add(_cpu.AmountOfCores).Add(_cpu.PresenceOfVideoCore).Add(_cpu.Frequency).Add(_cpu.Tdp).Add(_cpu.PowerConsumption);
        }

        Cpu cpu = cpuBuilder.Build();
        Result? withCpu = WithCpu(cpu);
        if (withCpu == Result.Success)
        {
            _cpu = cpu;
            Build();
        }
    }

    public void CpuDebuilder(PresenceOfVideoCore characteristic)
    {
        var cpuBuilder = new Cpu.CpuBuilder();
        if ((_cpu?.AmountOfCores != null) && (_cpu.Socket != null) && (_cpu.Frequency != null) && (_cpu.Tdp != null) && (_cpu.PowerConsumption != null) && (_cpu != null))
        {
            cpuBuilder.Add(characteristic).Add(_cpu.AmountOfCores).Add(_cpu.Socket).Add(_cpu.Frequency).Add(_cpu.Tdp).Add(_cpu.PowerConsumption);
        }

        Cpu cpu = cpuBuilder.Build();
        Result? withCpu = WithCpu(cpu);
        if (withCpu == Result.Success)
        {
            _cpu = cpu;
            Build();
        }
    }

    public void CpuDebuilder(CoreFrequency characteristic)
    {
        var cpuBuilder = new Cpu.CpuBuilder();
        if ((_cpu?.AmountOfCores != null) && (_cpu.Socket != null) && (_cpu.PresenceOfVideoCore != null) && (_cpu.Tdp != null) && (_cpu.PowerConsumption != null) && (_cpu != null))
        {
            cpuBuilder.Add(characteristic).Add(_cpu.AmountOfCores).Add(_cpu.Socket).Add(_cpu.PresenceOfVideoCore).Add(_cpu.Tdp).Add(_cpu.PowerConsumption);
        }

        Cpu cpu = cpuBuilder.Build();
        Result? withCpu = WithCpu(cpu);
        if (withCpu == Result.Success)
        {
            _cpu = cpu;
            Build();
        }
    }

    public void CpuDebuilder(MaxTdp characteristic)
    {
        var cpuBuilder = new Cpu.CpuBuilder();
        if ((_cpu?.AmountOfCores != null) && (_cpu.Socket != null) && (_cpu.PresenceOfVideoCore != null) && (_cpu.Frequency != null) && (_cpu.PowerConsumption != null) && (_cpu != null))
        {
            cpuBuilder.Add(characteristic).Add(_cpu.AmountOfCores).Add(_cpu.Socket).Add(_cpu.PresenceOfVideoCore).Add(_cpu.Frequency).Add(_cpu.PowerConsumption);
        }

        Cpu cpu = cpuBuilder.Build();
        Result? withCpu = WithCpu(cpu);
        if (withCpu == Result.Success)
        {
            _cpu = cpu;
            Build();
        }
    }

    public void CpuDebuilder(PowerConsumption characteristic)
    {
        var cpuBuilder = new Cpu.CpuBuilder();
        if ((_cpu?.AmountOfCores != null) && (_cpu.Socket != null) && (_cpu.PresenceOfVideoCore != null) && (_cpu.Frequency != null) && (_cpu.Tdp != null) && (_cpu != null))
        {
            cpuBuilder.Add(characteristic).Add(_cpu.AmountOfCores).Add(_cpu.Socket).Add(_cpu.PresenceOfVideoCore).Add(_cpu.Frequency).Add(_cpu.Tdp);
        }

        Cpu cpu = cpuBuilder.Build();
        Result? withCpu = WithCpu(cpu);
        if (withCpu == Result.Success)
        {
            _cpu = cpu;
            Build();
        }
    }

    public Computer? Build()
    {
        if (_fan != null)
        {
            if (_frame != null)
            {
                if (_powerUnit != null)
                {
                    if (_ram != null)
                    {
                        if (_videoCard != null)
                            return new Computer(_cpu, _fan, _frame, _motherboard, _powerUnit, _ram, _drives, _videoCard);
                    }
                }
            }
        }

        return null;
    }

    // public void AddingToArchive(ArchiveOfComputers archiveOfComputers)
    // {
    //     archiveOfComputers?.AddComputer(_newComputer);
    // }
    public Result? Builder(Cpu? cpu, Fan fan, IFrame frame, IList<IDrive> memorylist, Ram ram, Motherboard motherboard, PowerUnit powerUnit, VideoCard videoCard)
    {
        throw new System.NotImplementedException();
    }
}