using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle, IVehicle
    {
        private const double defaultMileage = 450;
        public PassengerCar(string brand, string model, string licensePlateNumber) : base(brand, model, defaultMileage, licensePlateNumber)
        {

        }
    }
}
