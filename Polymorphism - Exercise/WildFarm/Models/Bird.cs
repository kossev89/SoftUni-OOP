using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]");
            return sb.ToString().Trim();
        }
    }
}
