using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel, double fuelConsumption) : base(horsePower, fuel, fuelConsumption)
        {
            DefaultFuelConsumption = 3;
        }

    }
}
