namespace Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

public class JumpEngineAlpha : Engines
{
    // расход топлива на минимальную длину маршрутка - короткий
    private int _wastedFuel;
    private JumpEngineAlpha()
    {
        _wastedFuel = 1;
    }

    public override int CalculationOfFuelAtSpeed(Spaces space)
    {
        // чем больше скорость, тем больше расход топлива
        int num = 1;
        for (int i = 0; i < space.LenghthOfRoute; i++)
        {
            num = num * i;
        }

        _wastedFuel = num * _wastedFuel;

        // линейно растущая скорость
        return _wastedFuel;
    }
}