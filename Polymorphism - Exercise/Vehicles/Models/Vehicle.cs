using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value <= TankCapacity)
                {
                    fuelQuantity = value;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    fuelQuantity = 0;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {value} fuel in the tank");
                    fuelQuantity = 0;
                }
            }
        }

        public virtual double FuelConsumption { get; set; }
        public int TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            double neededFuel = FuelConsumption * distance;
            if (neededFuel > FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }
        public virtual void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (fuelQuantity + quantity > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
                else
                {
                    FuelQuantity += quantity;
                }
            }
        }
    }
}
