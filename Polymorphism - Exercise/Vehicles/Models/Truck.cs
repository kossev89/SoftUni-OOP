using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + quantity > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
                else
                {
                    FuelQuantity += quantity*0.95;
                }
            }
        }
    }
}
