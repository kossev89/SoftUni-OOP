using NUnit.Framework;
using System.Net;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GarageCheckCapacity()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");
            Vehicle car4 = new("VW", "Gold1", "P2959AS");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            bool actualResult = garage.AddVehicle(car4);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void AddVeh
    }
}