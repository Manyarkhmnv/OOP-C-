using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.JumpEngine;

public class JumpEngineOmega : Engines
{
    // расход топлива на минимальную длину маршрутка - короткий
    private int _wastedFuel;
    internal JumpEngineOmega()
    {
        _wastedFuel = 1;
    }

    public override int CalculationOfFuelAtSpeed(Spaces space)
    {
        // чем больше скорость, тем больше расход топлива
        double num = space.LenghthOfRoute * Math.Log(space.LenghthOfRoute, 2);

        _wastedFuel = (int)(num * _wastedFuel);

        // логарифмически растущая скорость
        return _wastedFuel;
    }
}