namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ImpulseEngineE : Engines
{
    // расход топлива на минимальную длину маршрутка - короткий
    private int _wastedFuel;

    internal ImpulseEngineE()
    {
        _wastedFuel = 1;
    }

    public override int CalculationOfFuelAtSpeed(Spaces space)
    {
        // чем больше скорость, тем больше расход топлива
        int num = 2;
        for (int i = 0; i < space.LenghthOfRoute; i++)
        {
            num = num * 2;
        }

        _wastedFuel = num * _wastedFuel;

        // экспоненциально растущая скорость
        return _wastedFuel;
    }
}