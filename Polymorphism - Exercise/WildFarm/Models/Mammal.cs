using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal
    {

        private string livingRegion;

        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]");
            return sb.ToString().Trim();
        }

    }
}
