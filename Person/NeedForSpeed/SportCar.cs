using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel, double fuelConsumption) : base(horsePower, fuel, fuelConsumption)
        {
            DefaultFuelConsumption = 10;
        }
    }
}
