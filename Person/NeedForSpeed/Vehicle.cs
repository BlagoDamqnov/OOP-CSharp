using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel, double fuelConsumption)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            DefaultFuelConsumption = 1.25;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption{ get; set; }
        public double DefaultFuelConsumption { get; set; }


        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers;
        }

    }
}
