using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    internal class CargoVan: Vehicle, IVehicle
    {
        private const double defaultMileage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber) : base(brand, model, defaultMileage, licensePlateNumber)
        {
        }

        public override void Drive(double mileage)
        {
            int currentValue = BatteryLevel;
            int percentage = (int)(mileage / MaxMileage+5);
            SetBatteryLevelValue(currentValue -= percentage);
        }
    }
}
