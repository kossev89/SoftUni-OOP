using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption+0.9, tankCapacity)
        {
        }
    }
}
