using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        public SpecializedArm(int interfaceStandard, int batteryUsage) : base(10045, 10000)
        {
        }
    }
}
