namespace Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

public class JumpEngineGamma : Engines
{
    // расход топлива на минимальную длину маршрутка - короткий
    private int _wastedFuel;
    internal JumpEngineGamma()
    {
        _wastedFuel = 1;
    }

    public override int CalculationOfFuelAtSpeed(Spaces space)
    {
        int num = space.LenghthOfRoute;

        // чем больше скорость, тем больше расход топлива
        for (int i = 0; i < space.LenghthOfRoute; i++)
        {
            num = num * num;
        }

        _wastedFuel = (int)(num * _wastedFuel);

        // квадратически растущая скорость
        return _wastedFuel;
    }
}