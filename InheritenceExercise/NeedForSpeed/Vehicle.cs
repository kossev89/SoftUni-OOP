using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {

        public Vehicle(double fuel, int horsePower)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        private const double DefaultFuelConsumption = 1.25;

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }

    }
}
