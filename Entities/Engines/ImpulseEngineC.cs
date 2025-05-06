namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ImpulseEngineC : Engines
{
    // расход топлива на минимальную длину маршрутка - короткий
    private int _wastedFuel;

    internal ImpulseEngineC()
    {
        _wastedFuel = 1;
    }

    public override int CalculationOfFuelAtSpeed(Spaces space)
    {
        _wastedFuel = space.LenghthOfRoute * 5;
        return _wastedFuel;
    }
}