using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel, double fuelConsumption) : base(horsePower, fuel, fuelConsumption)
        {
            DefaultFuelConsumption = 8;
        }
    }
}
