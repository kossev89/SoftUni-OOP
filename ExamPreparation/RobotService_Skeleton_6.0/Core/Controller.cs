using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements = new();
        private RobotRepository robots = new();
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            switch (typeName)
            {
                case "DomesticAssistant":
                    DomesticAssistant domesticAssistant = new(model);
                    robots.AddNew(domesticAssistant);
                    break;
                case "IndustrialAssistant":
                    IndustrialAssistant industrialAssistant = new(model);
                    robots.AddNew(industrialAssistant);
                    break;
            }
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            switch (typeName)
            {
                case "SpecializedArm":
                    SpecializedArm specialized = new();
                    supplements.AddNew(specialized);
                    break;
                case "LaserRadar":
                    LaserRadar laserRadar = new();
                    supplements.AddNew(laserRadar);
                    break;
            }
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> robotsCopy = robots.Models();
            List<IRobot> suitableRobots = new();
            int remainingPower = totalPowerNeeded;

            foreach (var item in robotsCopy)
            {
                if (item.InterfaceStandards.Contains(intefaceStandard))
                {
                    suitableRobots.Add(item);
                }
                else
                {
                    continue;
                }
            }

            if (suitableRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            var suitableRobotsOrdered = suitableRobots.OrderByDescending(x => x.BatteryLevel).ToList();
            int batterySum = suitableRobotsOrdered.Sum(x => x.BatteryLevel);
            if (batterySum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - batterySum));
            }
            int counter = 0;
            foreach (var item in suitableRobotsOrdered)
            {
                if (item.BatteryLevel>=totalPowerNeeded)
                {
                    item.ExecuteService(totalPowerNeeded);
                    counter++;
                    break;
                }
                else
                {
                    remainingPower -= item.BatteryLevel;
                    item.ExecuteService(totalPowerNeeded);
                    totalPowerNeeded = remainingPower;
                    counter++;
                    continue;
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);

        }

        public string Report()
        {
            var reportList = robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(x => x.BatteryCapacity);
            StringBuilder sb = new();
            foreach (var item in reportList)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToFeed = robots.Models().Where(x=>x.Model==model).Where(x => x.BatteryLevel < x.BatteryCapacity / 2).ToList();
            foreach (var item in robotsToFeed)
            {
                item.Eating(minutes);
            }
            return string.Format(OutputMessages.RobotsFed, robotsToFeed.Count());
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var supplementToUpgrade = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            var robotsToUpgrade = robots.Models().Where(x => x.InterfaceStandards.Contains(supplementToUpgrade.InterfaceStandard) == false).Where(x => x.Model == model);
            if (robotsToUpgrade.Any() == false)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            var robotToUpgrade = robotsToUpgrade.First();
            robotToUpgrade.InstallSupplement(supplementToUpgrade);
            supplements.RemoveByName(supplementToUpgrade.GetType().Name);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
