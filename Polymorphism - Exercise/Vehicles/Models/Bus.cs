using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double neededFuel = (FuelConsumption + 1.4) * distance;
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

        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }

    }
}
