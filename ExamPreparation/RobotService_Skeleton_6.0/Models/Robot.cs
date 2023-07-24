using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int convertionCapacityIndex;
        private int batteryLevel;
        private IReadOnlyCollection<int> interfaceStandards;
        private List<int> interfaceStandardsList;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            this.model = model;
            this.batteryCapacity = batteryCapacity;
            this.convertionCapacityIndex = convertionCapacityIndex;
            this.interfaceStandardsList = new();
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (batteryCapacity < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get => batteryLevel;
            private set
            {
                batteryLevel = batteryCapacity;
            }
        }

        public int ConvertionCapacityIndex { get => convertionCapacityIndex; private set => convertionCapacityIndex = value; }

        public IReadOnlyCollection<int> InterfaceStandards
        {
            get => interfaceStandards;
            private set
            {
                interfaceStandards = interfaceStandardsList;
            }
        }

        public void Eating(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                batteryLevel += ConvertionCapacityIndex;
                if (batteryLevel >= BatteryCapacity)
                {
                    batteryLevel = batteryCapacity;
                    return;
                }
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (batteryLevel >= consumedEnergy)
            {
                batteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandardsList.Add(supplement.InterfaceStandard);
            batteryCapacity -= supplement.BatteryUsage;
            batteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            if (interfaceStandards.Any())
            {
                sb.AppendLine($"--Supplements installed: {string.Join(' ', interfaceStandards)}");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: none");
            }
            return sb.ToString().Trim();
        }
    }
}
