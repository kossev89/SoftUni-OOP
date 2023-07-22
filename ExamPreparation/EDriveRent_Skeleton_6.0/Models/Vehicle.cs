using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.brand = brand;
            this.model = model;
            this.maxMileage = maxMileage;
            this.licensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{ExceptionMessages.BrandNull}");
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{ExceptionMessages.ModelNull}");
                }
            }
        }

        public double MaxMileage { get => maxMileage; private set => maxMileage = value; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{ExceptionMessages.LicenceNumberRequired}");
                }
            }
        }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void ChangeStatus()
        {
            if (IsDamaged == true)
            {
                IsDamaged = false;
            }
            else
            {
                IsDamaged = true;
            }
        }

        public virtual void Drive(double mileage)
        {
            int percentage = (int)(mileage / MaxMileage*100);
            BatteryLevel -= percentage;
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        protected void SetBatteryLevelValue(int newValue) // sets the battery level from the child class
        {
            BatteryLevel = newValue;
        }

        public override string ToString()
        {
            string status = string.Empty;
            if (IsDamaged == true)
            {
                status = "damaged";
            }
            else
            {
                status = "OK";
            }
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status:{status}";
        }
    }
}
