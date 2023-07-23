using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;

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
        public void AddVehicleWhenTheSameCarIsPresent()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P9667BX");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);

            bool actualResult = garage.AddVehicle(car3);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public void AddVehicleWhenEverythingIsOK()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            int expexterResult = 3;
            int actualResult = garage.Vehicles.Count;

            Assert.AreEqual(expexterResult, actualResult);
        }
        [Test]
        public void ChargeVehicles_IncreaseCount()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P9667BX");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            int batteryLevel = 100;

            car.BatteryLevel = 80;
            car.BatteryLevel = 100;
            car.BatteryLevel = 70;

            int actualResult =garage.ChargeVehicles(batteryLevel);
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveVehicle_WhenVehicleIsDamaged()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            car.IsDamaged = true;

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

           garage.DriveVehicle("P3366BC", 60, false);
            int expectedValue = 100;
            int actualValue = car.BatteryLevel;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DriveVehicle_WhenBatteryDrainageIsMoreThan100()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            garage.DriveVehicle("P3366BC", 101, false);
            int expectedValue = 100;
            int actualValue = car.BatteryLevel;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DriveVehicle_WhenBatteryDrainageIsMoreBatteryLevel()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            car.BatteryLevel = 69;

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            garage.DriveVehicle("P3366BC", 70, false);
            int expectedValue = 69;
            int actualValue = car.BatteryLevel;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DriveVehicle_WhenOK()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            car.BatteryLevel = 100;

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            garage.DriveVehicle("P3366BC", 70, false);
            int expectedValue = 30;
            int actualValue = car.BatteryLevel;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DriveVehicle_WhenAccidentOccured()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            car.BatteryLevel = 100;

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            garage.DriveVehicle("P3366BC", 70, true);
            bool expectedValue = true;
            bool actualValue = car.IsDamaged;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DriveVehicle_WithoutAccidentOccured()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            garage.DriveVehicle("P3366BC", 70, false);
            bool expectedValue = false;
            bool actualValue = car.IsDamaged;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void RepairVehicles_IncreaseCount()
        {
            Garage garage = new Garage(3);

            Vehicle car = new("Pegeot", "306", "P3366BC");
            Vehicle car2 = new("Toyota", "Corolla", "P9667BX");
            Vehicle car3 = new("VW", "Golf", "P2959AK");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);

            car.IsDamaged = true;
            car2.IsDamaged = false;
            car3.IsDamaged = true;


            string actualResult = garage.RepairVehicles();
            string expectedResult = "Vehicles repaired: 2";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsFalse(car.IsDamaged);
            Assert.IsFalse(car2.IsDamaged);
            Assert.IsFalse(car3.IsDamaged);
        }

        [TestFixture]
        public class VehicleTests
        {
            [Test]
            public void ConstructorSetsRightParameters()
            {
                string brand = "VW";
                string model = "Golf";
                string licensePlate = "P2959AK";

                Vehicle car = new(brand, model, licensePlate);

                Assert.AreEqual(car.Brand, brand);
                Assert.AreEqual(car.Model, model);
                Assert.AreEqual(car.LicensePlateNumber, licensePlate);
                Assert.AreEqual(car.BatteryLevel, 100);
                Assert.AreEqual(car.IsDamaged, false);
            }
        }
    }
}