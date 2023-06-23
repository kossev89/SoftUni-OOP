using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
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
